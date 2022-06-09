import SideBar from "@modules/sidebar";

let sidebarElements: HTMLCollectionOf<Element> = document.getElementsByClassName('sidebar');

if (sidebarElements) {
    let sidebar: HTMLElement = Array.from(sidebarElements)[0] as HTMLElement; 

    new SideBar(sidebar)
}

