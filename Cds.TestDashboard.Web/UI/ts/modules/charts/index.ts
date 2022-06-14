import { Chart, registerables } from 'chart.js';

export default class CdsChart {
    chartElement: HTMLCanvasElement;
    chart: Chart;
    config: any;

    constructor(_element: HTMLCanvasElement) {
        this.chartElement = _element;

        let chartId: string = this.chartElement.getAttribute('data-config-id') as string;

        this.config = (window as any)[chartId];

        Chart.register(...registerables);

        this.chart = new Chart(this.chartElement, this.config);
    }
}