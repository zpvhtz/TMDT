let obj_pie = {}
let lbl_pie = []
let dt_pie = []
let lblstr_pie = "";
let temp_pie = 0;

function LoadDuLieuPie() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            dt_pie = [];
            lbl_pie = [];
            obj_pie = JSON.parse(this.responseText);
            //console.log(dt_pie);
            //xconsole.log(lbl_pie);
            for (let i = 0; i < obj_pie.length; i++) {
                lbl_pie.push(obj_pie[i]["TenLoaiNguoiDung"]);
                dt_pie.push(parseInt(obj_pie[i]["SoLuong"]));
            }
            if (dt_bar < 1000000) {
                temp_pie = Math.round((Math.max(...dt_pie) / 200000)) * 200000 + 200000
            }
            if (dt_bar > 1000000) {
                temp_pie = Math.round((Math.max(...dt_pie) / 2000000)) * 2000000 + 2000000
            }
            let temp2 = (Math.max(...dt) / 200000)

            Test_pie();

        }
    };
    xhttp.open("GET", "https://localhost:44386/Webmaster/Home/GetSoLuongNguoiDung?nbd=" + nbd.toString(), true);
    xhttp.send();
}

function Test_pie() {

    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#292b2c';

    // Pie Chart Example
    var ctx = document.getElementById("myPieChart");
    var myPieChart = new Chart(ctx, {
        type: 'pie',
        data: {
            //labels: ["Customer", "MerChant", "Disabled",],
            labels: lbl_pie,
            datasets: [{
                //data: [12.21, 15.58, 11.25],
                data: dt_pie,
                backgroundColor: ['#fca14b','#007bff', '#dc3545',],
            }],
        },
    });
}
