


//test
function AddMeueAccordionMenuLink(obj, title, src) {
    var element = $("#" + obj)
    element.accordion('add', {
        title: title,
        content: src,
        selected: true,
        iconCls: 'icon-ok',
        padding: '1px'
    });
 
}

/*
 *  EasyUi-Tab插件的操作，进行js代码二次封装，提高代码复用性
 */
/*
 * obj:  控件的Id
 * title:tab的标题
 * src:  tab的iframe连接url
 */

//无论是增加、还是刷新，都调用该方法
function FlushTabs(obj, title, src) {
    var isExit = ExistsWindowTab(obj,title);
    log("isexit:" ,isExit);
    if (!isExit) {
        log("增加tab:" , title);
        AddTabs(obj, title, src);
        
    } else {
        log("更新Tab:", title);
        UpdateTabs(obj, title, src);
        
    }
}

//Tab增加
function AddTabs(obj, title, src) {
    log("AddTabs-obj:" , obj);
    var windowTab = $("#" + obj);
    log("Add-windowTab:" , windowTab);
    var plus = '<iframe id="frmWorkArea" width="100%" height="100%" frameborder="0" scrolling="auto" style="width:100%;height:100%;"  src="' + src + '"></iframe>';
    windowTab.tabs('add', {
        title: title,
        content: plus,
        closable: true,
        fit: true,
        iconCls: 'icon-save'
    });
}

//tab刷新
function UpdateTabs(obj, title, src) {
    var windowTab = $("#" + obj);
    log("UpdateTabs:", windowTab);
    var plus = '<iframe id="frmWorkArea" width="100%" height="100%" frameborder="0" scrolling="auto" style="width:100%;height:100%;"  src="' + src + '"></iframe>';
    log("需要更新的Tab:" ,title);
    windowTab.tabs('select', title);
    var windowTab2 = $("#" + obj).tabs('getSelected');
    log("updateTabs2:" , windowTab2);
    windowTab.tabs('update', {
        tab: windowTab2,
        options: {
            title: title,
            content: plus,
            closable: true,
            fit: true
        }
    });
}
//判断当前Tab是否存在
function ExistsWindowTab(obj, title) {
    var windowTab = $("#" + obj);
    log("判定Tab:" , title + "是否存在..");
    //如果不存在返回false
    var isExit = windowTab.tabs('exists', title);
    log("判定结果:" , isExit);
    return isExit;
}
/******************************tab操作结束*****************************************/
