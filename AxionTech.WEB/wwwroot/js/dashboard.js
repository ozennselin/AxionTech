document.addEventListener("DOMContentLoaded", function () {

    var salesChartCanvas = document.getElementById('salesChart');

    if (salesChartCanvas) {

        var context = salesChartCanvas.getContext('2d');

        var salesChartData = {
            labels: ['Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran','Temmuz','Ağustos','Eylül','Ekim','Kasım','Aralık'],
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
    $('#turkey-map').vectorMap({
        map: 'turkey',
        backgroundColor: 'transparent',
        borderColor: '#2d8cff',
        borderOpacity: 1,
        borderWidth: 1,
        color: '#ffffff',
        hoverColor: '#f39c12',
        enableZoom: true,
        showTooltip: true,

        onRegionClick: function (event, code, region) {
            alert(region + ' şehrine tıklandı');
        }
    });
});