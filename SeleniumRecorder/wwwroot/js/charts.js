//-----------------------------------------------------------------------
//============ ALL JAVASCRIPT PRODUCED EXCLUSIVELY FOR AWAIT ============
//-----------------------------------------------------------------------
// LINE - Chart js
var ctx = document.getElementById('lineChart').getContext('2d');
const data_line_chart = {
    labels: ['March', 'April', 'May', 'June', 'July', 'August'],
    datasets: [
        {
            label: 'Tests Completed',
            data: [10, 15, 12, 8, 16, 20],
            backgroundColor: 'rgba(41, 218, 41, 0.1)',
            borderColor: 'rgba(41, 218, 41, 0.5)',
            fill: false,
            tension: 0.3,
        },
        {
            label: 'Tests Failed',
            data: [5, 8, 10, 6, 12, 15],
            backgroundColor: 'rgba(218, 41, 41, 0.1)',
            borderColor: 'rgba(218, 41, 41, 0.5)',
            fill: false,
            tension: 0.3,
        },
        {
            label: 'Suit Ratio',
            data: [12, 10, 8, 14, 10, 6],
            backgroundColor: 'rgba(75, 192, 192, 0.1)',
            borderColor: 'rgba(75, 192, 192, 0.5)',
            fill: false,
            tension: 0.3,
        },
    ],
};
var lineChart = new Chart(ctx, {
    type: 'line',
    data: data_line_chart,
    options: {
        responsive: true,
        maintainAspectRatio: false,
        scales: {
            x: {
                display: true,
            },
            y: {
                display: true,
            },
        },
        plugins: {
            tooltip: {
                mode: 'nearest',
            },
            hover: {
                mode: 'index',
            },
            interaction: {
                intersect: true,
            },
        },
        elements: {
            line: {
                borderWidth: 2, // Initial border width
            },
        },
        onHover: function (event, chartElement) {
            if (chartElement.length > 0) {
                var hoveredDatasetIndex = chartElement[0].datasetIndex;
                var chart = chartElement[0].chart;

                // Reset line colors and border widths
                lineChart.data.datasets.forEach(function (dataset, datasetIndex) {
                    var dataset = lineChart.data.datasets[datasetIndex];
                    if (dataset.label == 'Tests Completed') {
                        dataset.borderColor = 'rgba(41, 218, 41, 0.5)';
                        dataset.backgroundColor = 'rgba(41, 218, 41,, 0.1)';
                        dataset.borderWidth = 2;

                    } else if (dataset.label == 'Tests Failed') {
                        dataset.borderColor = 'rgba(218, 41, 41, 0.5)';
                        dataset.backgroundColor = 'rgba(218, 41, 41, 0.1)';
                        dataset.borderWidth = 2;

                    } else if (dataset.label == 'Suit Ratio') {
                        dataset.borderColor = 'rgba(75, 192, 192, 0.5)';
                        dataset.backgroundColor = 'rgba(75, 192, 192, 0.1)';
                        dataset.borderWidth = 2;
                    }
                });

                // Set hover color and border width for the hovered dataset
                var hoveredDataset = lineChart.data.datasets[hoveredDatasetIndex];
                if (hoveredDataset.label == 'Tests Completed') {
                    hoveredDataset.borderColor = 'rgba(41, 218, 41, 0.8)';
                    hoveredDataset.backgroundColor = 'rgba(41, 218, 41, 0.5)';
                    hoveredDataset.borderWidth = 2.5;

                } else if (hoveredDataset.label == 'Tests Failed') {
                    hoveredDataset.borderColor = 'rgba(218, 41, 41, 0.8)';
                    hoveredDataset.backgroundColor = 'rgba(218, 41, 41, 0.5)';
                    hoveredDataset.borderWidth = 2.5;

                } else if (hoveredDataset.label == 'Suit Ratio') {
                    hoveredDataset.borderColor = 'rgba(75, 192, 192, 0.8)';
                    hoveredDataset.backgroundColor = 'rgba(75, 192, 192, 0.5)';
                    hoveredDataset.borderWidth = 2.5;
                }
                lineChart.update();
            }
        },
    },
});
// POLAR - Chart js
var ctx = document.getElementById('polarChart').getContext('2d');
background_color = ['rgb(218, 41, 41)', 'rgb(43, 198, 226)', 'rgb(153, 43, 226)', 'rgb(41, 218, 41)'];
data_set = ['65%', '35%', '94%', '30%']
var radarChart = new Chart(ctx, {
    type: 'polarArea',
    data: {
        labels: ['Avg.Success Score', 'Avg.Response Time Score', 'Avg.WEL-Accuracy Score ', 'Avg.Load Time Score'],
        datasets: [{
            data: [65, 35, 94, 30],
            backgroundColor: [
                'rgb(218, 41, 41, 0.5)',
                'rgb(43, 198, 226, 0.5)',
                'rgb(153, 43, 226, 0.5)',
                'rgb(41, 218, 41, 0.5)'
            ],
            borderColor: [
                'rgb(218, 41, 41, 0.8)',
                'rgb(43, 198, 226, 0.8)',
                'rgb(153, 43, 226, 0.8)',
                'rgb(41, 218, 41, 0.8)'
            ],
        }],
    },
    options: {
        responsive: true,
        maintainAspectRatio: false,
        layout: {
            padding: {
                left: 10
            }
        },
        scales: {
            r: {
                angleLines: {
                    color: 'rgb(0, 0, 0, 0.5)',
                },
                grid: {
                    color: 'rgb(255, 255, 255, 0.5)',
                },
                ticks: {
                    display: true,
                    backdropColor: 'rgb(0, 0, 0, 0)',
                    color: 'rgb(255, 255, 255, 0.8)'
                }
            },

        },
        plugins: {
            colors: {
                enabled: true
            },
            title: {
                display: true,
                text: 'SUIT POLAR RATIO',
                font: {
                    size: 16,
                },
            },
            legend: {
                display: false
            },
        },
    },
});
// POLAR - Chart js - Append Bootstrap classes to the label items
var labelsContainer = document.getElementById('chartLabels');
radarChart.data.labels.forEach(function (label, index) {
    var spanItem = document.createElement('span');
    spanItem.className = 'badge rounded-pill';
    spanItem.style = 'background-color:' + background_color[index];
    var listItem = document.createElement('li');
    listItem.className = 'list-group-item d-flex justify-content-between bg-dark align-items-start';
    listItem.textContent = label;
    spanItem.textContent = data_set[index];
    labelsContainer.appendChild(listItem);
    listItem.appendChild(spanItem);
});
// BAR - Chart js
var ctx = document.getElementById('barChart').getContext('2d');
var barChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ['Errors', 'Warnings', 'Console Errors'],
        datasets: [
            {
                label: 'Errors',
                data: [0],
                backgroundColor: 'rgba(255, 99, 132, 0.6)',
                borderColor: 'rgba(255, 99, 132, 1)',
                borderWidth: 2,
            },
            {
                label: 'Warnings',
                data: [0],
                backgroundColor: 'rgba(255, 159, 64, 0.6)',
                borderColor: 'rgba(255, 159, 64, 1)',
                borderWidth: 2,
            },
            {
                label: 'Console Errors',
                data: [0],
                backgroundColor: 'rgba(75, 192, 192, 0.6)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 2,
            },
        ],
    },
    options: {
        responsive: true,
        maintainAspectRatio: false,
        scales: {
            x: {
                stacked: true
            },
            y: {
                border: {
                    display: false
                },
                beginAtZero: true,
                stacked: true,
                ticks: {
                    font: {
                        size: 15
                    }
                }
            }
        },
        plugins: {
            title: {
                display: true,
                text: 'SUIT OVERVIEW',
                font: {
                    size: 20,
                },
            },
            legend: {
                display: false,
            },
        },
        layout: {
            padding: {
                left: 0, // Adjust as needed
                right: 0,
                top: 0,
                bottom: 0,
            },
        },
        categorySpacing: 0.4,
        indexAxis: 'y',
        barPercentage: 0.9, // Adjust the bar width
        categoryPercentage: 0.8, // Adjust the space between bars
    }
});
// RADAR - Chart js
var ctx = document.getElementById('radarChart').getContext('2d');
const data = {
    labels: [
        'TAG',
        'ELEMENT ID',
        'CSS SINGLE',
        'CSS SELECTOR',
        'XPATH'
    ],
    datasets: [
        {
            label: 'Web-Element Presence(%)',
            data: [15, 15, 20, 45, 5],
            backgroundColor: 'rgba(171, 0, 177, 0.1)',
            borderColor: 'rgb(242, 0, 255, 0.5)',
            pointBackgroundColor: 'rgb(255, 0, 106, 0.5)',
            pointBorderColor: 'rgb(255, 0, 106)',
            pointHoverBackgroundColor: 'rgb(171, 0, 177, 0.8)',
            pointHoverBorderColor: 'rgb(171, 0, 177)'
        },
        {
            label: 'Web-Element Accuracy(%)',
            data: [59, 65, 75, 90, 82],
            backgroundColor: 'rgba(0, 152, 179, 0.1)',
            borderColor: 'rgb(0, 152, 179, 0.5)',
            pointBackgroundColor: 'rgb(0, 152, 179, 0.8)',
            pointBorderColor: 'rgb(0, 217, 255)',
            pointHoverBackgroundColor: 'rgb(0, 152, 179, 0.8)',
            pointHoverBorderColor: 'rgb(0, 217, 255)'
        }
    ]
};
var radarChart = new Chart(ctx, {
    type: 'radar',
    data: data,
    options: {
        elements: {
            line: {
                borderWidth: 1
            }
        },
        responsive: true,
        maintainAspectRatio: false,
        layout: {
            padding: {
                left: 10
            }
        },
        scales: {
            r: {
                angleLines: {
                    display: false
                },
                grid: {
                    color: 'rgb(255, 255, 255, 0.3)',
                },
                ticks: {
                    display: true,
                    backdropColor: 'rgb(0, 0, 0, 0)',
                    borderColor: 'rgb(255, 255, 255, 0.8)',
                    color: 'rgb(255, 255, 255, 0.8)',
                    backdropPadding: 10
                }
            },

        },
        plugins: {
            colors: {
                enabled: true
            },
            title: {
                display: true,
                text: 'SUIT WEB-ELEMENT',
                font: {
                    size: 16,
                },
            },
        },
    }
});
// Function to animations
function animateCount() {
    var count_errors = 0;
    var target_errors = 12;
    var interval_errors = setInterval(function () {
        if (count_errors >= target_errors) {
            clearInterval(interval_errors);
        } else {
            count_errors++;
            barChart.data.datasets[0].data[0] = count_errors;
            barChart.update();
        }
    }, 100);

    var count_warnings = 0;
    var target_warnings = 16;
    var interval_warnings = setInterval(function () {
        if (count_warnings >= target_warnings) {
            clearInterval(interval_warnings);
        } else {
            count_warnings++;
            barChart.data.datasets[1].data[1] = count_warnings;
            barChart.update();
        }
    }, 100);

    var count_console = 0;
    var target_console = 2;
    var interval_console = setInterval(function () {
        if (count_console >= target_console) {
            clearInterval(interval_console);
        } else {
            count_console++;
            barChart.data.datasets[2].data[2] = count_console;
            barChart.update();
        }
    }, 100);
}
// Call the animateCount function when the page loads
animateCount();
//------------------------------------------------------
//============ BUILT BY: Branden van Staden ============
//------------------------------------------------------