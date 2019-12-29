var page = 0,
    inCallback = false,
    isReachedScrollEnd = false;


var scrollHandler = function ()
{
    if ((isReachedScrollEnd == false) &&
        ($(document).height() - $(this).height() - 300 < $(this).scrollTop()))
    {
        loadProjectData(url);
    }
}


function loadProjectData(loadMoreRowsUrl) {
    if (page > -1 && !inCallback) {
        inCallback = true;
        page++;
        //$("div#loading").show();
        //debugger
        $.ajax({
            type: 'GET',
            url: loadMoreRowsUrl,
            data: "pageNum=" + page,
            //data: { pageNum: page, newsSource: source },//fixed with url in index.cxhtml
            success: function (articles, textstatus) {
                if (articles != '') {
                    $(".row").append(articles);
                    showmodal(loadMoreRowsUrl);
                    $("time.timeago").timeago();
                }
                else {
                    page = -1;
                }

                inCallback = false;
                //$("div#loading").hide();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });

    }
} 