﻿var Maps = function () {
    "use strict";
    //function to initiate GMaps
    //Gmaps.js allows you to use the potential of Google Maps in a simple way.
    //For more information, please visit http://hpneo.github.io/gmaps/documentation.html
    var runMaps = function () {
        // Basic Map 
        var paths = document.getElementById("cph_MasterBody_hf2").value;
        var latitud = 16.7520118411463;
        var longitud = -93.10650222939148;
        if (paths.length > 0)
        {
            var array2d = JSON.parse(paths);
            if (array2d.length > 0) {
                if (array2d[0].length > 0) {
                    latitud = array2d[0][0];
                    longitud = array2d[0][1];
                }
            }
        }
        //console.log(latitud + ' ' + longitud);
        var map = new GMaps({
            el: '#map1',
            lat: latitud,
            lng: longitud,
            zoom: 12,
            click: function (e) {
            },
            dragend: function (e) {
            }
        });
        
        if (paths.length > 0) {
            var CustomPol = map.drawPolygon({
                paths: array2d,
                strokeColor: '#BBD8E9',
                strokeOpacity: 1,
                strokeWeight: 3,
                fillColor: '#BBD8E9',
                fillOpacity: 0.6
            });

            var points = document.getElementById("cph_MasterBody_hf3").value;//'[["B", 16.227733737053, -93.9108153899063, "AVENIDA QUINTA GIRASOLES, MANZANA 06, INFONAVIT SAN ISIDRO, CÓDIGO POSTAL 30450", "ENTRE LAS CALLES EL PASAJE Y LAS PALMAS."],["C1", 16.227733737053, -93.9108153899063, "AVENIDA QUINTA GIRASOLES, MANZANA 06, INFONAVIT SAN ISIDRO, CÓDIGO POSTAL 30450", "ENTRE LAS CALLES EL PASAJE Y LAS PALMAS."],["C2", 16.227733737053, -93.9108153899063, "AVENIDA QUINTA GIRASOLES, MANZANA 06, INFONAVIT SAN ISIDRO, CÓDIGO POSTAL 30450", "ENTRE LAS CALLES EL PASAJE Y LAS PALMAS."]]';
                         //[[16.2193925265761, -93.89194935636985], [16.21934432743343, -93.89193143932386], [16.21718314878007, -93.89345591303045], [16.21721134173348, -93.89350580835081], [16.21783998410592, -93.89428846607808], [16.21789612855137, -93.8943796569196], [16.21916276912284, -93.89595896585243], [16.21921890441857, -93.89604274100763], [16.21926111280068, -93.89610573199049], [16.22021004806605, -93.89731937156579], [16.22031580913239, -93.89743985465837], [16.22042157012276, -93.89756033787893], [16.2234377189381, -93.89537223429916], [16.22451871879932, -93.89629470705535], [16.22491477208969, -93.89582092654199], [16.22498852683292, -93.89590249632106], [16.22566879368317, -93.89660258798658], [16.22577695476734, -93.89671471464853], [16.22635257162948, -93.89729294691547], [16.2271911137491, -93.89642598286972], [16.22721130554897, -93.89645791762102], [16.22777900223339, -93.89735577579734], [16.22845247427213, -93.89843319929979], [16.22849726153859, -93.89850972768434], [16.22826756205567, -93.89888483240762], [16.2285369194497, -93.89910081894261], [16.22892021457993, -93.89936931470224], [16.22837519496234, -93.90023638405238], [16.22568212434175, -93.90452062901122], [16.22517653434936, -93.90525893675699], [16.22555211598199, -93.90567461276403], [16.22611163243584, -93.90641779675649], [16.2266583637788, -93.90713578305206], [16.22758335429306, -93.90628999754463], [16.22831927929192, -93.90696620293295], [16.22799112648556, -93.90726092485454], [16.22744352365467, -93.90780266416084], [16.22801148625726, -93.90857124735548], [16.22724228127192, -93.90932025782421], [16.227900713918, -93.91018332761101], [16.22797809155746, -93.91030462733191], [16.22846855205619, -93.91097879501811], [16.22880316952517, -93.91146027521596], [16.22897983994482, -93.91148813424391], [16.22860652864998, -93.91181910140297], [16.22837305502715, -93.91205341673162], [16.22826619414668, -93.91215259942057], [16.22809932018815, -93.91230748282398], [16.22749908116543, -93.91289873341334], [16.22724953912124, -93.91315005097256], [16.22692270293229, -93.91351092936475], [16.2264560951964, -93.91401999471329], [16.22589836910665, -93.91455746002276], [16.22569660573532, -93.91475189280446], [16.22559564565474, -93.91484918453523], [16.22442926226483, -93.91597463052466], [16.22242855660385, -93.91786296356877], [16.22478329586794, -93.9212693655429], [16.22514175713893, -93.92179844612915], [16.22543742926355, -93.92224006034488], [16.22582245714813, -93.92279251508484], [16.22617808774598, -93.92333883413615], [16.22610593219888, -93.92348614267439], [16.22826813929321, -93.92667854783744], [16.22850479761898, -93.9266443907684], [16.22955959877596, -93.92649214973005], [16.23145807862912, -93.92460545020224], [16.23121004125425, -93.92526127527464], [16.23162978905896, -93.92644600540919], [16.23159105145675, -93.92707265609437], [16.2318000570077, -93.9274659442967], [16.23192639775421, -93.92791806072661], [16.23172380644196, -93.92900364414281], [16.23123052959471, -93.92998227951331], [16.23014174313344, -93.92960469982666], [16.22969421717863, -93.92944950392563], [16.22886461644828, -93.92935521641988], [16.22840712825187, -93.92902465288418], [16.22815617657943, -93.92851858647627], [16.22782280636191, -93.92812822612324], [16.22719924744917, -93.92774468426792], [16.22657494665275, -93.92719051018028], [16.22624231502267, -93.92697078963842], [16.22561998942985, -93.92687164450955], [16.22508106888347, -93.92688430753562], [16.22491429616427, -93.92688822619975], [16.22450069288337, -93.92689794465471], [16.22387811991315, -93.92674192345712], [16.22362740926455, -93.92629274893615], [16.22343999408973, -93.92609806215802], [16.22325257871395, -93.92590337574814], [16.22287898485426, -93.92579839003174], [16.22204987597927, -93.92581787648088], [16.22180114330569, -93.92582372242137], [16.22117881661758, -93.92572458386424], [16.22061063483009, -93.92556428426327], [16.22043162834265, -93.92551461616019], [16.22038583335833, -93.92538781866162], [16.21989196464021, -93.92535665429931], [16.21921101802475, -93.92482401636799], [16.21867822189973, -93.92422118007926], [16.21832349224568, -93.92371153823805], [16.21799187314542, -93.92301728333537], [16.2173928471437, -93.92225251557882], [16.21734296186219, -93.92216316631442], [16.21723788896861, -93.92197471178939], [16.21704011654825, -93.92128108552565], [16.21695388575894, -93.92058797859211], [16.21691297043837, -93.91973345101506], [16.21687075246565, -93.91917909024741], [16.2167867114535, -93.91797801022814], [16.2167218807453, -93.91749281588602], [16.21674523603432, -93.91684153573985], [16.21603473910092, -93.91554999844226], [16.2155752223848, -93.91476448666155], [16.21453482340791, -93.91387890438666], [16.21407555093062, -93.91315027711805], [16.21365697770326, -93.91225005176499], [16.21377857996056, -93.91162149760051], [16.21431423290125, -93.91086941787002], [16.21485164545918, -93.91051545972238], [16.21543051306359, -93.9101605220563], [16.21617520241018, -93.90980167150944], [16.21650583942567, -93.90956634743482], [16.21604730834616, -93.90900834824626], [16.21575510235132, -93.9085601903754], [16.21529808214808, -93.9083434471315], [16.21517119213694, -93.90777762897075], [16.21450411496588, -93.90694015369593], [16.21570253582463, -93.90605865127456], [16.21528291966793, -93.90493093049493], [16.2145690504531, -93.90290006525432], [16.2137302855638, -93.90075840272219], [16.21297746697585, -93.89929729375496], [16.21264046956783, -93.89811076618075], [16.21093705625799, -93.8959065828349], [16.21108184788172, -93.89401373145894], [16.2120154010066, -93.89320463731185], [16.21247408837813, -93.89281664905582], [16.21468921310897, -93.89271548275956], [16.21526574415448, -93.89184861260752], [16.21625914005909, -93.89148380253586], [16.21637914007014, -93.89051396934299], [16.21732876385339, -93.88963824778676], [16.2175969394249, -93.88934748440398], [16.21786511463078, -93.88905672023245], [16.21844394962416, -93.88870171303205], [16.21881524812126, -93.88829473824762], [16.21893806946668, -93.88795053222798], [16.21897565849949, -93.88709640115161], [16.2193513378141, -93.88765632602117], [16.21997471917443, -93.88798285222082], [16.22072298197519, -93.88842018813614], [16.22155415499772, -93.88885556331746], [16.22263174497541, -93.88877315189966], [16.22321212428702, -93.88875940277875], [16.22379018653113, -93.8882337520602], [16.2243685052371, -93.88776497642621], [16.2249071712405, -93.88769532849197], [16.22515848089834, -93.88825821829384], [16.22516156969588, -93.88894075847081], [16.22495789225837, -93.88974196453731], [16.22450445031421, -93.8903215464409], [16.22402024078962, -93.89132652859983], [16.22127344445111, -93.89066641537782], [16.22074638230127, -93.89157727498291], [16.22067394219659, -93.8917256141058], [16.22011056793523, -93.89151070098593], [16.21884107827736, -93.8908678601511], [16.21873758912359, -93.89106807669947], [16.21870144017116, -93.89113801257656], [16.21866746705756, -93.89120373888595], [16.21856180173834, -93.89140816460812], [16.21944214682581, -93.89187935434666], [16.2193925265761, -93.89194935636985]]

            var arrayPoints2d = JSON.parse(points);
            console.log(arrayPoints2d.length);
            //console.log(arrayPoints2d);
            for(var k = 0; k< arrayPoints2d.length; k++)
            {
                map.addMarker({
                    lat: arrayPoints2d[k][1],
                    lng: arrayPoints2d[k][2],
                    title: arrayPoints2d[k][0],
                    infoWindow: {
                        content:  '<p> Casilla: ' + arrayPoints2d[k][0] + '</p>'
                                + '<p> Dirección: ' + arrayPoints2d[k][3] + '</p>'
                                + '<p> Referencias: ' + arrayPoints2d[k][4] + '</p>'
                    }
                });
            }

            //CustomPol.addListener('click', DibujarPunto);

            //function DibujarPunto(event) {
            //    //map.removeMarkers();
            //    //var index = map.markers.length;
            //    //var lat = event.latLng.lat();
            //    //var lng = event.latLng.lng();
            //    //document.getElementById("hfLatitud").value = lat;
            //    //document.getElementById("hfLongitud").value = lng;
            //    //map.addMarker({
            //    //    lat: lat,
            //    //    lng: lng
            //    //});
            //}
        }
       
    };
    return {
        //main function to initiate template pages
        init: function () {
            runMaps();
        }
    };
}();