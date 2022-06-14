import CdsChart from "@modules/charts";
import SideBar from "@modules/sidebar";

let sidebarElements: HTMLCollectionOf<Element> = document.getElementsByClassName('sidebar');

if (sidebarElements) {
    let sidebar: HTMLElement = Array.from(sidebarElements)[0] as HTMLElement; 

    new SideBar(sidebar)
}

let doughnutCharts: HTMLCollectionOf<HTMLCanvasElement> = document.getElementsByClassName('js-chart') as HTMLCollectionOf<HTMLCanvasElement>;

if (doughnutCharts) {
    let charts: HTMLCanvasElement[] = Array.from(doughnutCharts);

    charts.forEach((chart: HTMLCanvasElement) => { new CdsChart(chart) });
}
