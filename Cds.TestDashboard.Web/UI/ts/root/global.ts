import CdsChart from "@modules/charts";
import SideBar from "@modules/sidebar";
import TabCollection from "@modules/tabCollection";

let sidebarElements: HTMLCollectionOf<Element> = document.getElementsByClassName('sidebar');

if (sidebarElements) {
    let sidebar: HTMLElement = Array.from(sidebarElements)[0] as HTMLElement; 

    new SideBar(sidebar)
}

let chartCollection: HTMLCollectionOf<HTMLCanvasElement> = document.getElementsByClassName('js-chart') as HTMLCollectionOf<HTMLCanvasElement>;

if (chartCollection) {
    let charts: HTMLCanvasElement[] = Array.from(chartCollection);

    charts.forEach((chart: HTMLCanvasElement) => { new CdsChart(chart) });
}

let tabCollections: HTMLCollectionOf<HTMLElement> = document.getElementsByClassName('js-tab-collection') as HTMLCollectionOf<HTMLElement>;

if (tabCollections) {
    let tabCollectionsList: HTMLElement[] = Array.from(tabCollections);

    tabCollectionsList.forEach((element: HTMLElement) => new TabCollection(element))
}
