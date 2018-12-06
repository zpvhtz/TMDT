let obj = {}
let lbl = []
let dt = []
let lblstr = "";
let temp = 0;
function LoadDuLieu1() {
    console.log("LOG")
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            obj = JSON.parse(this.responseText);
            for (let i = 0; i < obj.length; i++) {
                lbl.push(obj[i]["Thang"]);
                dt.push(parseInt(obj[i]["ThuNhap"]));
            }
            let temp2 = (Math.max(...dt) / 200000)
            console.log(temp2)
            temp = Math.round((Math.max(...dt) / 200000)) * 200000 + 200000
            Test();
            Test2();

        }
    };
    xhttp.open("GET", "https://localhost:44386/Webmaster/Home/GetThongKeMerchant", true);
    xhttp.send();
}





function Test() {



    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#292b2c';

    // Bar Chart Example
    var ctx = document.getElementById("myBarChart");
    var myLineChart = new Chart(ctx, {
      type: 'bar',
      data: {
          //labels: ["January", "February", "March", "April", "May", "June"],
          labels: lbl
          datasets: [{
          label: "Revenue",
          backgroundColor: "rgba(2,117,216,1)",
          borderColor: "rgba(2,117,216,1)",
          //data: [4215, 5312, 6251, 7841, 9821, 14984],
          data:dt,
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
              maxTicksLimit: 6
            }
          }],
          yAxes: [{
            ticks: {
              min: 0,
              max: temp,
              maxTicksLimit: 5
            },
            gridLines: {
              display: true
            }
          }],
        },
        legend: {
          display: false
        }
      }
    });
}