(function () {
    var actualizarhora = function () {
        var fecha = new Date(),
            hora = fecha.getHours(),
            minutos = fecha.getMinutes(),
            segundos = fecha.getSeconds(),
            diaSemana = fecha.getDay(),
            dia = fecha.getDate(),
            mes = fecha.getMonth(),
            year = fecha.getFullYear(),
            ampm;
        var pHoras = document.getElementById(horas);
        pSegundos = document.getElementById(segundos);
        pMinutos = document.getElementById(minutos);
        pAMPM = document.getElementById(ampm);
        pDiaSemana = document.getElementById(diaSemana);
        pDia = document.getElementById(dia);
        pMes = document.getElementById(mes);
        pYear = document.getElementById(year);

        var semana = ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'];
        pDiaSemana.textcontent = semana[diaSemana];
        pDia.textcontent = dia;

        var meses = ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'];
        pMes.textcontent = meses[mes];
        pYear.textcontent = year;


        if (horas >= 12) {
            horas = horas - 12;
            ampm = 'PM';
        } else {
            ampm = 'AM';
        }

        if (horas == 0) {
            horas == 12;
        };
        pHoras.textContent = horas;
        pAMPM.textContent = ampm;

        pMinutos.textContent = minutos;
        pSegundos.textContent = segundos;

    };


    actualizarhora();