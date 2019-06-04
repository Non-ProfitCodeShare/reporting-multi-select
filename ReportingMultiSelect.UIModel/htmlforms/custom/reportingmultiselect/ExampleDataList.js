(function (c, d) {
    var e, b, a;
    e = "SHOWAPPLICATIONSFORM";
    b = "SHOWTRANSACTIONTYPESFORM";
    a = BBUI.forms.Utility;
    c.on("formupdated", function (h) {
        var i, g, j, f;
        j = h.formUpdateResult;
        g = a.findActionInFormUpdateResult(j, e, d);
        if (g) {
            if (g.enabled) {
                i = e
            }
        } else {
            f = a.findActionInFormUpdateResult(j, b, d);
            if (f && f.enabled) {
                i = b
            }
        }
        if (i) {
            c.invokeAction(d, i)
        }
    })
})();