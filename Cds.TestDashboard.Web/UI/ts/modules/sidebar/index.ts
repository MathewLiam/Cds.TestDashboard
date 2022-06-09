export default class SideBar {
    sidebarElement: HTMLElement;
    sidebarLinks: NodeListOf<HTMLAnchorElement>;
    activeLink?: HTMLElement;
    
    constructor(_element: HTMLElement) {
        this.sidebarElement = _element;
        this.sidebarLinks = _element.querySelectorAll('a');
        this.setActiveTab();
    }


    private setActiveTab() {
        console.log(this.sidebarLinks);
        Array.from(this.sidebarLinks).forEach((link: HTMLAnchorElement) => {
            if (link.href == window.location.href || window.location.href.includes(link.href) && !this.activeLink) {
                link.classList.toggle('active', true);
                this.activeLink = link;
            }
        });
    }
}