document.addEventListener("DOMContentLoaded", function () {

    var salesChartCanvas = document.getElementById('salesChart');

    if (salesChartCanvas) {

        var context = salesChartCanvas.getContext('2d');

        var salesChartData = {
            labels: ['Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran'],
            datasets: [
                {
                    label: 'Satış',
                    data: monthlySales,
                    backgroundColor: 'rgba(60,141,188,0.9)'
                }
            ]
        };

        var salesChartOptions = {
            responsive: true,
            maintainAspectRatio: false
        };

        new Chart(context, {
            type: 'bar',
            data: salesChartData,
            options: salesChartOptions
        });
    }

});