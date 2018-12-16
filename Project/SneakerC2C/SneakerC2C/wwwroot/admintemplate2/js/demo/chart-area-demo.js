﻿let obj = {}
let lbl = []
let dt = []
let lblstr = "";
let temp = 0;

function LoadDuLieuArea(nbd, nkt) {
    Clear();
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            dt = [];
            lbl = [];
            //console.log(dt);
            //console.log(lbl);
            obj = JSON.parse(this.responseText);
            for (let i = 0; i < obj.length; i++) {
                lbl.push(obj[i]["Thang"]);
                dt.push(parseInt(obj[i]["ThuNhap"]));
            }
            let temp2 = (Math.max(...dt) / 200000)
            if (dt < 100000) {
                temp = Math.round((Math.max(...dt) / 20000)) * 20000 + 20000
            }
            else
            {
                if (dt < 1000000) {
                    temp = Math.round((Math.max(...dt) / 200000)) * 200000 + 200000
                }
                else {
                        temp = Math.round((Math.max(...dt) / 2000000)) * 2000000 + 2000000
                }                                  
            }
            Test();


        }
    };
    xhttp.open("GET", "https://localhost:44386/Webmaster/Home/GetThongKeQuangCao?nbd=" + nbd.toString() + "&nkt=" + nkt.toString(), true);
    xhttp.send();
}
function LoadDuLieuArea1(nbd, nkt) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            dt = [];
            lbl = [];
            obj = JSON.parse(this.responseText);
            for (let i = 0; i < obj.length; i++) {
                lbl.push(obj[i]["Thang"]);
                dt.push(parseInt(obj[i]["ThuNhap"]));
            }
            let temp2 = (Math.max(...dt) / 200000)
            if (dt < 100000) {
                temp = Math.round((Math.max(...dt) / 20000)) * 20000 + 20000
            }
            else {
                if (dt < 1000000) {
                    temp = Math.round((Math.max(...dt) / 200000)) * 200000 + 200000
                }
                else {
                    temp = Math.round((Math.max(...dt) / 2000000)) * 2000000 + 2000000
                }
            }
            Test1();

        }
    };
    xhttp.open("GET", "https://localhost:44386/Webmaster/Home/GetThongKeGianHang?nbd=" + nbd.toString() + "&nkt=" + nkt.toString(), true);
    xhttp.send();
}

function Test() {
    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#292b2c';
    // Area Chart Example
    var ctx = document.getElementById("myAreaChart");
    var myLineChart = new Chart(ctx, {
        type: 'line',
        data: {
            //labels: ["Mar 1", "Mar 2", "Mar 3", "Mar 4"],
            labels: lbl,
            datasets: [{
                label: "Doanh Thu",//ten cột
                lineTension: 0.3,
                backgroundColor: "rgba(2,117,216,0.2)",
                borderColor: "rgba(2,117,216,1)",
                pointRadius: 5,
                pointBackgroundColor: "rgba(2,117,216,1)",
                pointBorderColor: "rgba(255,255,255,0.8)",
                pointHoverRadius: 5,
                pointHoverBackgroundColor: "rgba(2,117,216,1)",
                pointHitRadius: 50,
                pointBorderWidth: 2,
                //data: [10000, 30162, 1, 18394, 18287, 28682, 1, 33259, 25849, 24159, 32651, 31984, 38451],
                data: dt,
            }],
        },
        options: {
            scales: {
                xAxes: [{
                    time: {
                        unit: 'date'
                    },
                    gridLines: {
                        display: true // gach doc
                    },
                    ticks: {
                        maxTicksLimit: 100 // max 100 thang

                    }
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        //max: 1000000,
                        max: temp,
                        maxTicksLimit: 10
                    },
                    gridLines: {
                        color: "rgba(0, 0, 0, .125)",
                    }
                }],
            },
            legend: {
                display: false
            }
        }
    });
}

function Test1() {
    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#292b2c';
    // Area Chart Example
    var ctx = document.getElementById("myAreaChart1");
    var myLineChart = new Chart(ctx, {
        type: 'line',
        data: {
            //labels: ["Mar 1", "Mar 2", "Mar 3", "Mar 4"],
            labels: lbl,
            datasets: [{
                label: "Doanh Thu",//ten cột
                lineTension: 0.3,
                backgroundColor: "rgba(2,117,216,0.2)",
                borderColor: "rgba(2,117,216,1)",
                pointRadius: 5,
                pointBackgroundColor: "rgba(2,117,216,1)",
                pointBorderColor: "rgba(255,255,255,0.8)",
                pointHoverRadius: 5,
                pointHoverBackgroundColor: "rgba(2,117,216,1)",
                pointHitRadius: 50,
                pointBorderWidth: 2,
                //data: [10000, 30162, 1, 18394, 18287, 28682, 1, 33259, 25849, 24159, 32651, 31984, 38451],
                data: dt,
            }],
        },
        options: {
            scales: {
                xAxes: [{
                    time: {
                        unit: 'date'
                    },
                    gridLines: {
                        display: true // gach doc
                    },
                    ticks: {
                        maxTicksLimit: 100 // max 100 thang

                    }
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        //max: 1000000,
                        max: temp,
                        maxTicksLimit: 10
                    },
                    gridLines: {
                        color: "rgba(0, 0, 0, .125)",
                    }
                }],
            },
            legend: {
                display: false
            }
        }
    });
}

function Clear() {
    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#292b2c';
    // Area Chart Example
    var ctx = document.getElementById("myAreaChart");
    var myLineChart = new Chart(ctx, {
        type: 'line',
        data: {
            //labels: ["Mar 1", "Mar 2", "Mar 3", "Mar 4"],
            labels: null,
            datasets: [{
                label: "Doanh Thu",//ten cột
                lineTension: 0.3,
                backgroundColor: "rgba(2,117,216,0.2)",
                borderColor: "rgba(2,117,216,1)",
                pointRadius: 5,
                pointBackgroundColor: "rgba(2,117,216,1)",
                pointBorderColor: "rgba(255,255,255,0.8)",
                pointHoverRadius: 5,
                pointHoverBackgroundColor: "rgba(2,117,216,1)",
                pointHitRadius: 50,
                pointBorderWidth: 2,
                //data: [10000, 30162, 1, 18394, 18287, 28682, 1, 33259, 25849, 24159, 32651, 31984, 38451],
                data: null,
            }],
        },
        options: {
            scales: {
                xAxes: [{
                    time: {
                        unit: 'date'
                    },
                    gridLines: {
                        display: true // gach doc
                    },
                    ticks: {
                        maxTicksLimit: 100 // max 100 thang

                    }
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        //max: 1000000,
                        max: temp,
                        maxTicksLimit: 10
                    },
                    gridLines: {
                        color: "rgba(0, 0, 0, .125)",
                    }
                }],
            },
            legend: {
                display: false
            }
        }
    });
}