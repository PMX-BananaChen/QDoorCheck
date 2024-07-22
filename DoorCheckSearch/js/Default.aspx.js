// JScript File

$(function(){
    loadAreas();
    $("#OK").click(search);
    $("#exportToExcel").click(exportToExcel);
    $("#from").datepicker({dateFormat:'yy-mm-dd',defaultDate:new Date(),gotoCurrent:true});
    $("#to").datepicker({dateFormat:'yy-mm-dd',defaultDate:new Date(),gotoCurrent:true});
    
    var now=new Date();
    
    $("#from").val(String.format("{0:yyyy-MM-dd}",now));
    $("#to").val(String.format("{0:yyyy-MM-dd}",now));
});

function loadAreas()
{
    $.ajax({
        type:"POST",
        url:"search.ashx",
        data:{act:"GetAllAreas"},
        dataType:"json",
        success:loadAreas_callback
    });
}

function loadAreas_callback(result)
{
    //var areas=Sys.Serialization.JavaScriptSerializer.deserialize(result);
    var areas=result;
    var $areas=$("#areas");
    var $temp=$("<option></option>");
    
    $temp.clone().val("").text("<ALL>").appendTo($areas);
    
    for(var i=0;i<areas.length;i++)
    {
        $area=$temp.clone().val(areas[i].Sid).text(areas[i].AreaName).appendTo($areas);        
    }
}

function search()
{
    $("#OK").attr("disabled",true);
    $("#loading").css("display","block");
    $("#view").empty();

    var areaId=$("#areas").val();
    var keyvalue=$("#keyValue").val();
    var datefrom=$("#from").val();
    var dateto=$("#to").val();
    
    $.ajax({
        type:"POST",
        url:"search.ashx",
        data:{act:"Search",area:areaId,keyValue:keyvalue,from:datefrom,to:dateto},
        dataType:"json",
        success:search_callback
    });
}

function exportToExcel()
{
    var areaId=$("#areas").val();
    var keyvalue=$("#keyValue").val();
    var datefrom=$("#from").val();
    var dateto=$("#to").val();
    
    var url="ExportToExcel.aspx?area="+areaId+"&from="+datefrom+"&to="+dateto+"&keyValue="+keyvalue;
    window.open(url);
}

function search_callback(result)
{
    //var recs=Sys.Serialization.JavaScriptSerializer.deserialize(result);
    var recs=result;
    result="";
    result=null;
    CollectGarbage(); 
    
    var $tr=$("<tr></tr>");
    var $th=$("<th></th>");
    var $td=$("<td></td>");
    
    var $t=$("<table></table>").attr("id","result");
    
    var $thead=$("<thead></thead>");
    $tr.clone().append($th.clone().attr("width","50px").text("NO."))
                .append($th.clone().attr("width","80px").text("車間"))
                .append($th.clone().attr("width","80px").text("卡號"))
                .append($th.clone().attr("width","80px").text("工號"))
                .append($th.clone().attr("width","80px").text("姓名"))
                .append($th.clone().attr("width","100px").text("時間"))
                .append($th.clone().attr("width","300px").text("Memo"))
                .appendTo($thead);
                
    var $tbody=$("<tbody></tbody>");
    for (var i=0;i<recs.length;i++)
    {
        $tr.clone().append($td.clone().text(i+1))
                .append($td.clone().text(recs[i].Area))
                .append($td.clone().text(recs[i].PersonCard))
                .append($td.clone().text(recs[i].PersonWorkNo))
                .append($td.clone().text(recs[i].PersonName))
                .append($td.clone().text(recs[i].Time.format("yyyy-MM-dd HH:mm")))
                .append($td.clone().text(recs[i].Memo))
                .appendTo($tbody);
        
    }
    
    recs="";
    recs=null;
    CollectGarbage(); 
    
    $thead.appendTo($t);
    $tbody.appendTo($t);

    $("#loading").css("display","none");
    $("#OK").attr("disabled",false);
    $("#view").empty();
    $t.appendTo($("#view"));
    $("#result").flexigrid({width:765,height:600});        
}