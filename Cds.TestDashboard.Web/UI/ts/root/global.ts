import SideBar from "@modules/sidebar";

let sidebarElements: HTMLCollectionOf<Element> = document.getElementsByClassName('sidenav');

if (sidebarElements) {
    let sidebar: HTMLElement = Array.from(sidebarElements)[0] as HTMLElement; 

    new SideBar(sidebar)
}
