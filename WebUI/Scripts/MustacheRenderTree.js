//通过一些根据属性名称对应的标记定义模板
var _TreeProvice = [
      '<h1 class="l1"></h1>',
      '<div class="slist">',
           '<h2 class="l2"><a href="#">{{AreasName}}</a></h2>',
           ' <ul class="sslist">',
           '{{#Mistes}}<li class="l3"><a href="#">{{MsiteName}}</a></li>{{/Mistes}}',
           '</ul>',
           '</div>'
      
].join('');

//初始化这个模板
Mustache.parse(_TreeProvice);
function data2Html(data) {
    console.log("yes,begin")
    //data = data || [];
    //var curSysAry = data.filter(function (s) { return s.isCurrent; });
    //data.sort(function (a, b) { return a.sortOrder - b.sortOrder; });
    //data = data.map(function (s, i) { s.first = i == 0; return s });

    //模板渲染成字符串
    return Mustache.render(_TreeProvice, data);
}