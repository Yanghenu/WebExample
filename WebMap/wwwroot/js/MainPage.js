
var map = new AMap.Map('container', {
    resizeEnable: true
});
AMap.plugin('AMap.Geolocation', function () {
    var geolocation = new AMap.Geolocation({
        enableHighAccuracy: true,//是否使用高精度定位，默认:true
        timeout: 10000,          //超过10秒后停止定位，默认：5s
        buttonPosition: 'RB',    //定位按钮的停靠位置
        buttonOffset: new AMap.Pixel(10, 20),//定位按钮与设置的停靠位置的偏移量，默认：Pixel(10, 20)
        zoomToAccuracy: true,   //定位成功后是否自动调整地图视野到定位点

    });
    map.addControl(geolocation);
    geolocation.getCurrentPosition(function (status, result) {
        if (status == 'complete') {
            onComplete(result);
            InsertUserInfo(result);

            GetUserInfo();
        } else {
            onError(result);
            alert("请刷新界面并允许获取位置信息！");
        }
    });
});

function GetUserInfo() {
    $.ajax({
        url: "/MainPage/GetOtherUserInfo",
        type: "post",
        contentType: "application/json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                // 创建一个 Marker 实例：
                var marker = new AMap.Marker({
                    position: new AMap.LngLat(data[i].lng, data[i].lat),   // 经纬度对象，也可以是经纬度构成的一维数组[116.39, 39.9]
                    title: ''
                });
                // 将创建的点标记添加到已有的地图实例：
                map.add(marker);
            }
        }
        ,
        error: function (jqXHR, textStatus, errorThrown) {
            alert("error " + textStatus);
            return false;
        }
    });
}

//解析定位结果
function onComplete(data) {
    document.getElementById('status').innerHTML = '定位成功'
    var str = [];
    str.push('定位结果：' + data.position);
    str.push('定位类别：' + data.location_type);
    if (data.accuracy) {
        str.push('精度：' + data.accuracy + ' 米');
    }//如为IP精确定位结果则没有精度信息
    str.push('是否经过偏移：' + (data.isConverted ? '是' : '否'));
    document.getElementById('result').innerHTML = str.join('<br>');
}
//解析定位错误信息
function onError(data) {
    document.getElementById('status').innerHTML = '定位失败'
    document.getElementById('result').innerHTML = '失败原因排查信息:' + data.message;
}
//上传用户数据
function InsertUserInfo(data) {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    const userId = urlParams.get('id');
    $.ajax({
        url: "/MainPage/InsertUserInfo",
        type: "post",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ "Geolocation": data, "UserName": userId }),
        success: function (data) {

            if (data == 1) {
                console.log("Success");
            }
            else {
                alert("请刷新界面并允许获取位置信息！");
            }
        }
        ,
        error: function (jqXHR, textStatus, errorThrown) {
            alert("error " + textStatus);
            return false;
        }
    });
}
//window.addEventListener('beforeunload', function (event) {
    
    
//});


function UpdateStatus(data) {
    //const queryString = window.location.search;
    //const urlParams = new URLSearchParams(queryString);
    //const userId = urlParams.get('id');
    $.ajax({
        url: "/MainPage/UpdateStatus",
        type: "post",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {

        }
        ,
        error: function (jqXHR, textStatus, errorThrown) {
            alert("error " + textStatus);
            return false;
        }
    });
}