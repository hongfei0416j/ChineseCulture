(function () {
    $qrcode = $("#header-qrcode"); $headerLayer = $("#header-layer");
    $footerLayer = $("#footer-layer");
    $headerBtn = $("#header-tongzhen-btn");
    $footerBTN = $("#footer-tongzhen-btn");
    $headerBtn.on("click", function () {
        event.stopPropagation(); clickLog("pccitytown");
        $qrcode.toggle(); $headerLayer.toggle()
    });
    $footerBTN.on("click", function () {
        event.stopPropagation();
        clickLog("pccitytown");
        $footerLayer.toggle()
    }); $("body").on("click", function (event) {
        $qrcode.show(); $headerLayer.hide(); $footerLayer.hide()
    });
    function makeSelector(id, data, tag) {
        var $selector = $("#" + id); var $result = $("#" + id + "-result");
        var $options = $("#" + id + "-box"); var $arrow = $("#" + id + "-arrow");
        $selector.off("click");
        if (tag) { $result.html("城市") } $options.empty();
        $options.css("max-height", 15 * 30 + "px");
        for (key in data) {
            if (data.hasOwnProperty(key)) {
                $options.append($('<li class="selector-list" data-city="' + data[key] + '">' + key + "</li>"))
            }
        } $selector.on("click", function (event) { event.preventDefault(); for (var i = 0; i < $(".selector-box").length; i++) { if ($(".selector-box")[i] != $options[0]) { $(".selector-box").eq(i).hide() } } $options.toggle(); $arrow.toggleClass("selector-arrow-up") }); $selector.on("click", ".selector-list", function (event) {
            event.preventDefault();
            $result.html(event.target.innerHTML);
            if (tag == "city") {
                var address = "/";
                //if (catepath == "post")
                //{ address = "//post.zgxywhw2014.com/" + event.target.dataset["city"].split("|")[1] + "/" }
                //else { address = "//" + event.target.dataset["city"].split("|")[0] + ".zgxywhw2014.com/" + catepath }
                window.location.href = address
            } else if (tag == "foreign") {
                var address = "/";

                window.location.href = address
            }
            else {
                if (event.target.innerHTML == "海外") {
                    makeSelector("selector-city", cityList[event.target.innerHTML],
                        "foreign")
                } else {
                    makeSelector("selector-city", cityList[event.target.innerHTML], "city")
                }
            }
        }); $("body").eq(0).on("click", function (event) { if (event.target.className.indexOf("selector") == -1) { $options.hide(); $arrow.removeClass("selector-arrow-up") } })
    } function makeCityList() {
        var $contentBox = $("#content-box");
        $("#hot").append($('<div id="hot-title">热门城市</div>'));
        for (var cityName in independentCityList) {
            address = "/?city=" + cityName

            $("#hot").append($('<a href="' + address + '" class="hot-city">' + cityName + "</a>"))
        }
        var list = ["A", "F", "G", "H", "J", "L", "N", "Q", "S", "X", "Y", "Z", " "]; for (var i = 0; i < list.length; i++) {
            var $contentLetter = $('<div class="content-letter"><span class="content-letter-panel">' + list[i] + "</span></div>");
            $contentBox.append($contentLetter);
           

            for (var provinceName in provinceList) {
                if (provinceList[provinceName] == list[i]) {
                    var $contentProvince = $('<div class="content-province"><span class="content-province-triangle"></span><div class="content-province-title">' + provinceName + "</div></div>"); var $contentCities = $('<div class="content-cities"></div>'); var address = "";
                    for (var cityName in cityList[provinceName]) {
                        if (catepath == "post") { address = "//post.zgxywhw2014.com/" + cityList[provinceName][cityName].split("|")[1] + "/" }
                        else {
                            address = "/?city=" + cityName
                            //address = "//" + cityList[provinceName][cityName].split("|")[0] + ".zgxywhw2014.com/" + catepath
                        } if (provinceName == "海外") {
                            if (cityList[provinceName][cityName].split("|")[0] == "city") { address = "//g.zgxywhw2014.com/city/" }
                            else { address = "//g.zgxywhw2014.com/j-" + cityList[provinceName][cityName].split("|")[0] + "/" }
                        } $contentCities.append($('<a href="' + address + '" class="content-city">' + cityName + "</a>"))
                    } $contentProvince.append($contentCities); $contentLetter.append($contentProvince)
                }
            }
        } 
    } var search = window.location.search.replace("?", "").split("&"); var arg = []; window.catepath = ""; window.searchpath = ""; var catename = ""; for (var i = 0; i < search.length; i++) { arg[search[i].split("=")[0]] = search[i].split("=")[1] } for (key in arg) { if (key == "catepath" && arg[key] != "") { if (arg[key].indexOf(".shtml") > 0) { catepath = arg[key] } else if (arg[key].indexOf("post") == 0) { catepath = "post" } else { catepath = arg[key] + "/" } searchpath = arg[key] } else if (key == "catename" && arg[key] != "") { catename = decodeURIComponent(arg[key]) } else if (key == "fullpath") { window.fullpath = arg[key] } } makeSelector("selector-province", provinceList); makeCityList(); var $panels = $(".content-letter-panel"); var $letters = $(".content-letter"); var $provinceTitles = $(".content-province-title"); var $provinceTriangle = $(".content-province-triangle"); var $provinces = $(".content-province"); $provinces.each(function (index, el) { $provinceTitles.eq(index).css("height", $(el).css("height")); $(el).on("mouseover", function (event) { $provinceTriangle.eq(index).addClass("content-province-triangle-hover"); $(el).addClass("content-province-hover") }); $(el).on("mouseout", function (event) { $provinceTriangle.eq(index).removeClass("content-province-triangle-hover"); $(el).removeClass("content-province-hover") }) }); $letters.each(function (index, el) { $panels.eq(index).css({ height: $(el).css("height"), "line-height": $(el).css("height") }); $(el).on("mouseover", function (event) { $panels.eq(index).addClass("content-letter-panle-hover") }); $(el).on("mouseout", function (event) { $panels.eq(index).removeClass("content-letter-panle-hover") }) }); $("#selector-search-input").on("keydown", function (event) { if (event.keyCode == 13) { $("#selector-search-btn").click() } }); $("#selector-search-btn").on("click", function (event) { goCity(document.getElementById("selector-search-input").value, searchpath) }); var HD = window.devicePixelRatio; if (HD > 1) {
        $("#header").addClass("header-HD"); $("#logo").addClass("logo-HD"); $("#bangbang").addClass("bangbang-HD"); $("#header-qrcode").addClass("header-qrcode-HD"); $("#header-tongzhen-btn").addClass("header-tongzhen-btn-HD"); $("#footer-tongzhen-bangbang").addClass("footer-tongzhen-bangbang-HD"); $("#footer-tongzhen-btn").addClass("footer-tongzhen-btn-HD"); $(".tongzhen-iphone").addClass("tongzhen-iphone-HD");
        $(".tongzhen-qrcode").addClass("tongzhen-qrcode-HD"); $(".selector-arrow").addClass("selector-arrow-HD"); $(".content-province-triangle").addClass("content-province-triangle-HD")
    }
    $.ajax({
        url: "//www.zgxywhw2014.com/ipscript.aspx", type: "get", dataType: "xml", complete: function (result) {
            var city = "bj";
            if (result.status == 200)
            { city = result.responseText.split("//")[1].split(".zgxywhw2014.com")[0] }
            var cityname = "北京";
            for (var province in cityList)
            {
                for (var cityn in cityList[province])
                { if (cityList[province][cityn].split("|")[0] == city) { cityname = cityn; console.log(1); break } }
            }
            if (catename != "" && catepath != "") { $("#header-home-title").html(cityname + catename) }
            else { $("#header-home-title").html(cityname + "58同城") } $("#header-home-btn").on("click", function (event) { var address = ""; if (catepath == "post") { switch (city) { case "bj": address = "//post.zgxywhw2014.com/1/"; break; case "tj": address = "//post.zgxywhw2014.com/18/"; break; case "sh": address = "//post.zgxywhw2014.com/2/"; break; case "cq": address = "//post.zgxywhw2014.com/37/"; break; default: address = "//post.zgxywhw2014.com/" + cityList[province][cityname].split("|")[1] + "/" } } else { address = "//" + city + ".zgxywhw2014.com/" + catepath } for (cityName in cityList["海外"]) { if (cityList["海外"][cityName].split("|")[0] == city) { address = "//g.zgxywhw2014.com/j-" + city + "/" } } window.location.href = address }); $.ajax({ url: "//api.zgxywhw2014.com/comm/nearCities-" + city, type: "get", dataType: "jsonp", jsonpCallback: "nearcity", data: { api_callback: "nearcity" } })
        }
    })
})(); function nearcity(data) { $("#header-recommend").html("周边城市推荐:&nbsp;"); if (catepath == "post") { for (var i = 0; i < data.length; i++) { $("#header-recommend").append($('<a href="//post.zgxywhw2014.com/' + data[i].cityid + '/" class="recommend-city">' + data[i].name + "</a>")) } } else { for (var i = 0; i < data.length; i++) { $("#header-recommend").append($('<a href="//' + data[i].city + ".zgxywhw2014.com/" + catepath + '" class="recommend-city">' + data[i].name + "</a>")) } } } var _trackURL = "{'cate':'" + window.fullpath + "','area':'','pagetype':'changecity','page':''}";