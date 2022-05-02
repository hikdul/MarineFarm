


//Highcharts.chart('prueba', {

//    chart: {
//        styledMode: true
//    },

//    title: {
//        text: 'Pie de pruebas css'
//    },

//    xAxis: {
//        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
//    },

//    series: [{
//        type: 'pie',
//        allowPointSelect: true,
//        keys: ['name', 'y', 'selected', 'sliced'],
//        data: [
//            ['Manzanas', 29.9, false],
//            ['Peras', 71.5, false],
//            ['Naranjas', 106.4, false],
//            ['Plums', 129.2, false],
//            ['Cambures', 144.0, false],
//            ['Melocotones', 176.0, false],
//            ['Prunes', 135.6, true, true],
//            ['Aguacate', 148.5, false]
//        ],
//        showInLegend: true
//    }]
//});

//con este construllo una sola ves los pies
const crearPie = (nameOrId, title, list) => {

    let datos = []
    let cat=[]
    for (let i = 0; i < list.length; i++) {

        if(i==0)
            datos.push([list[i].name, list[i].y, true,true])
        else
            datos.push([list[i].name, list[i].y, list[i].selected])
        cat.push(list[i].text)
    }
    console.log('datos')
    console.log(datos)
    Highcharts.chart(nameOrId, {

        chart: {
            styledMode: true
        },

        title: {
            text: title
        },

        xAxis: {
            categories: cat
        },

        series: [{
            type: 'pie',
            allowPointSelect: true,
            keys: ['name', 'y', 'selected', 'sliced'],
            data: datos,
            showInLegend: true
        }]
    })

}


window.onload = function () {
    
    $.ajax({
        url: 'home/DatosPie', //archivo que recibe la peticion
        type: 'get', //método de envio
        success: function (resp) { //una vez que el archivo recibe el request lo procesa y lo devuelve
            crearPie('dia','Promedios Produccion Por Dia Laborado',resp.dia)
            crearPie('mes', 'Promedios Produccion Totales por mes', resp.mes)
        }
    });

}