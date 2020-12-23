// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

/*export function showPrompt(message) {
  return prompt(message, 'Type anything here');
}*/

window.amcharts = {

    //export function init(countPoints, chartModelsJson) {
    init: function (countPoints, chartModelsJson) {

        charts = [];  
        slider = {};
        countGPoints = countPoints;

        am4core.ready(function () {

            // Themes begin
            am4core.useTheme(am4themes_material);
            am4core.useTheme(am4themes_animated);
            // Themes end

            var chartModels = JSON.parse(chartModelsJson);           
            var number = 1;

            slider = createSlider();

            chartModels.forEach((element) => {

                var sensorName = "Sensor " + number.toString();
                charts.push(createChart(element.Id, sensorName));                
                number++;
            })

            function createSlider() {

                var chart = am4core.create("sliderdiv", am4charts.XYChart);
                chart.data = generateChartData();
                // Create axes
                var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
                dateAxis.dataFields.category = "Date";
                dateAxis.renderer.grid.template.location = 0.5;
                dateAxis.dateFormatter.inputDateFormat = "yyyy-MM-dd";
                dateAxis.renderer.minGridDistance = 50;

                dateAxis.events.on("startendchanged", dateAxisChanged);                

                var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

                // Create series
                var series = chart.series.push(new am4charts.LineSeries());
                series.dataFields.valueY = "value";
                series.dataFields.dateX = "date";
                series.strokeWidth = 2
                series.strokeOpacity = 0.3;

                //slider
                chart.scrollbarX = new am4core.Scrollbar();

                chart.plotContainer.visible = false;
                chart.leftAxesContainer.visible = false;
                chart.rightAxesContainer.visible = false;
                chart.bottomAxesContainer.visible = false;

                chart.cursor = new am4charts.XYCursor();
                chart.cursor.xAxis = dateAxis;

                chart.padding(0, 15, 0, 15);

                return chart;
            }

            function createChart(idChart, header) {

                // Create chart instance
                var chart = am4core.create(idChart, am4charts.XYChart);

                var title = chart.titles.create();
                title.text = header;
                title.fontSize = 25;
                title.marginBottom = 5;

                // Add data
                chart.data = generateChartData();

                // Create axes
                var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
                //dateAxis.renderer.minGridDistance = 50;
                dateAxis.groupData = true;
                dateAxis.groupCount = 1000;
                //подписка на изменение масштаба и скрол графика
                dateAxis.events.on("startendchanged", dateAxisChanged);
                
                var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

                // Create series
                var series = chart.series.push(new am4charts.LineSeries());
                series.minBulletDistance = 15;
                series.dataFields.valueY = "visits";
                series.dataFields.dateX = "date";
                series.strokeWidth = 2;
                series.tooltipText = "{valueY}";
                series.tooltip.pointerOrientation = "vertical";
                series.tooltip.background.cornerRadius = 20;
                //series.tooltip.background.fillOpacity = 0.5;
                series.tooltip.label.padding(12, 12, 12, 12);

                //рисование точек на графике
                var bullet = series.bullets.push(new am4charts.CircleBullet());
                //bullet.circle.stroke = am4core.color("#fff");
                //bullet.circle.strokeWidth = 1;

                // Add cursor
                chart.cursor = new am4charts.XYCursor();
                chart.cursor.xAxis = dateAxis;
                chart.cursor.snapToSeries = series;

                chart.svgContainer.autoResize = false;

                return chart;
            }

            function dateAxisChanged(ev) {
                
                slider.cursor.xAxis.start = ev.target.start;
                slider.cursor.xAxis.end = ev.target.end;
                charts.forEach((element) => {

                    element.cursor.xAxis.start = ev.target.start;
                    element.cursor.xAxis.end = ev.target.end;
                })
            }
        });
    }
};

function generateChartData() {
    var chartData = [];
    var firstDate = new Date();
    firstDate.setDate(firstDate.getDate());//-1000
    var visits = 1200;
    for (var i = 0; i < countGPoints; i++) {
        // we create date objects here. In your data, you can have date strings
        // and then set format of your dates using chart.dataDateFormat property,
        // however when possible, use date objects, as this will speed up chart rendering.
        var newDate = new Date(firstDate);
        newDate.setMinutes(newDate.getMinutes() + i);
        //newDate.setDate(newDate.getDate() + i);

        visits += Math.round((Math.random() < 0.5 ? 1 : -1) * Math.random() * 10);

        chartData.push({
            date: newDate,
            visits: visits
        });
    }
    return chartData;
}
