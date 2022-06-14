import CdsChart from "@modules/charts";

interface RequestResult {
    payload: any,
    isError: boolean
}

export default class TabCollection {
    tabSelector: string = '.js-tab';
    tabs: NodeListOf<Element>;
    queryParam: string;
    abortController: AbortController | undefined;
    element: HTMLElement;
    contentArea: HTMLElement;
    loadingTimeout: NodeJS.Timeout | undefined;
    state: any = {};

    constructor(_element: HTMLElement) {
        this.element = _element;
        let contentAreaClassName = this.element.getAttribute('data-content-area') as string;

        this.contentArea = document.getElementById(contentAreaClassName) as HTMLElement;

        this.tabs = document.querySelectorAll(this.tabSelector);

        this.queryParam = _element.getAttribute('data-query-param') as string;

        let queryString = window.location.search;
        let urlParams = new URLSearchParams(queryString);

        this.state.currentTab = urlParams.get(this.queryParam);

        this.setClickListeners();
    }

    private setClickListeners(): void {
        this.tabs.forEach((element: Element) => {
            element.addEventListener('click', async (e: Event) => {
                e.preventDefault();

                let currentTab: HTMLElement = e.currentTarget as HTMLElement;
                let tabName: string = currentTab.getAttribute('data-query-value') as string;
                let partialUrl: string = currentTab.getAttribute('data-partial-url') as string;
                
                if (this.state.currentTab !== tabName) {
                    
                    this.loadingTimeout = setTimeout(() => {
                        this.contentArea.innerHTML = `<div class="loader__container"><div class="loader" /></div>`;
                    }, 1000);

                    const { payload, isError }: RequestResult = await this.requestPartial(partialUrl);
                    
                    clearTimeout(this.loadingTimeout);

                    if (!isError) {
                        this.contentArea.innerHTML = payload;
                        
                        let queryString = new URLSearchParams(window.location.search);
                        queryString.set(this.queryParam, tabName);

                        window.history.pushState(this.state, '', `${window.location.pathname}?${queryString.toString()}`);

                        this.tabs.forEach((tab: Element) => {
                            tab.classList.toggle('active', false);
                        });
                        this.state.currentTab = tabName;
                        currentTab.classList.toggle('active', true);
                        this.initializeTabs();
                    }
                }
            })
        });
    }


    requestPartial(requestUrl: string): Promise<any> {
        if (this.abortController) {
            this.abortController.abort();
        }

        return new Promise(async (resolve) => {
            try {

                this.abortController = new AbortController();


                const result: Response = await fetch(requestUrl, {
                    method: 'GET',
                    signal: this.abortController.signal
                });

                if (result.ok) {
                    this.abortController = undefined;
                    const data: any = await result.text();
                    return resolve({
                        payload: data,
                        isError: false
                    } as RequestResult);
                } else {
                    return resolve({
                        payload: new Error(`${result.status} - ${result.statusText}`),
                        isError: true
                    } as RequestResult);
                }
            }
            catch (ex: any) {
                return resolve({
                    payload: ex.message,
                    isError: true
                } as RequestResult);
            }
        });
    }

    private initializeTabs(): void {
        let chartCollection: HTMLCollectionOf<HTMLCanvasElement> = document.getElementsByClassName('js-chart') as HTMLCollectionOf<HTMLCanvasElement>;

        if (chartCollection) {
            let charts: HTMLCanvasElement[] = Array.from(chartCollection);

            charts.forEach((chart: HTMLCanvasElement) => { new CdsChart(chart) });
        }
    }
}