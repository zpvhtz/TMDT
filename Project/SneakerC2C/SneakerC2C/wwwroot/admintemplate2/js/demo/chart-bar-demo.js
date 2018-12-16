let obj_bar = {}
let lbl_bar = []
let dt_bar = []
let lblstr_bar = "";
let temp_bar = 0;

function LoadDuLieuBar(nbd, nkt) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            dt_bar = [];
            lbl_bar = [];
            obj_bar = JSON.parse(this.responseText);
            console.log(dt_bar);
            for (let i = 0; i < obj_bar.length; i++) {
                lbl_bar.push(obj_bar[i]["Thang"]);
                dt_bar.push(parseInt(obj_bar[i]["DoanhThu"]));
            }
            if (dt_bar < 100000) {
                temp_bar = Math.round((Math.max(...dt_bar) / 20000)) * 20000 + 20000
            }
            else {
                if (dt_bar < 1000000) {
                    temp_bar = Math.round((Math.max(...dt_bar) / 200000)) * 200000 + 200000
                }
                else {
                    temp_bar = Math.round((Math.max(...dt_bar) / 2000000)) * 2000000 + 2000000
                }
            }
            let temp2_bar = (Math.max(...dt_bar) / 200000)

            console.log(temp_bar);
            Test_bar();

        }
    };
    xhttp.open("GET", "https://localhost:44386/Webmaster/Home/GetThongKeMerChant?nbd=" + nbd.toString() + "&nkt=" + nkt.toString(), true);
    xhttp.send();
}

function Test_bar() {

    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#292b2c';

    // Bar Chart Example
    var ctx = document.getElementById("myBarChart");
    var myLineChart = new Chart(ctx, {
      type: 'bar',
      data: {
          //labels: ["January", "February", "March", "April", "May", "June"],
          labels: lbl_bar,
          datasets: [{
          label: "Doanh Thu",
          backgroundColor: "rgba(2,117,216,1)",
          borderColor: "rgba(2,117,216,1)",
          //data: [4215, 5312, 6251, 7841, 9821, 14984],
              data: dt_bar,
        }],
      },
      options: {
        scales: {
          xAxes: [{
            time: {
              unit: 'month'
            },
            gridLines: {
              display: false
            },
            ticks: {
              maxTicksLimit: 10
            }
          }],
          yAxes: [{
            ticks: {
              min: 0,
                max: temp_bar,
              maxTicksLimit: 100
            },
            gridLines: {
              display: true
            }
          }],
        },
        legend: {
          display: true
        }
      }
    });
}