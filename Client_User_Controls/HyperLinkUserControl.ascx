<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HyperLinkUserControl.ascx.cs" Inherits="HyperLinkUserControl" %>
<script type="text/javascript">
    function hover(id) {
        var link = document.getElementById(id);
        $(link).animate(
            { rotation: 360 },
            {
                duration: 500,
                step: function (now, fx) {
                    $(this).css({ "transform": "rotate(" + now + "deg)" });
                }
            }
        );
    }
    function noHover(id) {
        var link = document.getElementById(id);
        $(link).animate(
            { rotation: 0 },
            {
                duration: 500,
                step: function (now, fx) {
                    $(this).css({ "transform": "rotate(" + now + "deg)" });
                }
            }
        );
    }
</script>
<a href=<%: Url %> style="text-decoration: none">
    <div id=<%: Id %> onmouseover="hover('<%: Id %>')" onmouseout="noHover('<%: Id %>')" style="padding: 10px; border-style: none; border-width: thin; background-color: #85c1e9; color: #ecf0f1; font-size: 1.4em; font-family: Lato, 'Helvetica Neue', Arial, sans-serif; text-align: center; width: 30px; height: 30px; float: left;">
        <%: Text %>
    </div>
</a>