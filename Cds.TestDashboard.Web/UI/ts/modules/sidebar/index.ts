export default class SideBar {
    sidebarElement: HTMLElement;
    
    constructor(_element: HTMLElement) {
        this.sidebarElement = _element;
        console.log('creating');
        this.addListeners();
    }

    private addListeners() {
        this.sidebarElement.addEventListener('mousedown', () => {
            console.log('mouse down');
            document.addEventListener("mousemove", this.resize, false);
            document.addEventListener("mouseup", () => {
                document.removeEventListener("mousemove", this.resize, false);
            }, false);
        })
    }

    private resize(e: MouseEvent) {
        const size = `${e.x}px`;
        this.sidebarElement.style.width = size;
    }

}