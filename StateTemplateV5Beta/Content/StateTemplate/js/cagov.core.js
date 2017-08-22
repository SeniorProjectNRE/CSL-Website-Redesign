﻿function addGAToDownloadLinks() {
    if (document.getElementsByTagName)
        for (var a = document.getElementsByTagName("a"), b = 0; b < a.length; b++) try {
            if ("mailto:" == a[b].protocol) startListening(a[b], "mousedown", trackMailto);
            else if ("tel:" == a[b].protocol) startListening(a[b], "mousedown", trackTelto);
            else if (a[b].hostname == location.host) {
                var c = a[b].pathname + a[b].search,
                    d = c.match(/\.(?:doc|docx|eps|jpg|png|svg|xls|xlsx|ppt|pptx|pdf|zip|txt|vsd|vxd|js|css|rar|exe|wma|mov|avi|wmv|mp3)($|\&|\?)/);
                d && startListening(a[b], "mousedown", trackExternalLinks)
            } else a[b].href.match(/^javascript:/) || startListening(a[b], "mousedown", trackExternalLinks)
        } catch (a) {
            continue
        }
}

function startListening(a, b, c) {
    a.addEventListener ? a.addEventListener(b, c, !1) : a.attachEvent && a.attachEvent("on" + b, c)
}

function trackMailto(a) {
    var b = a.srcElement ? a.srcElement.href : this.href,
        c = "/mailto/" + b.substring(7);
    _gaq.push(["_trackPageview", c]), _gaq.push(["b._trackPageview", c])
}

function trackTelto(a) {
    var b = a.srcElement ? a.srcElement.href : this.href,
        c = "/telto/" + b.substring(4);
    _gaq.push(["_trackPageview", c]), _gaq.push(["b._trackPageview", c])
}

function trackExternalLinks(a) {
    for (var b = a.srcElement ? a.srcElement : this;
        "A" != b.tagName;) b = b.parentNode;
    var c = "/" == b.pathname.charAt(0) ? b.pathname : "/" + b.pathname;
    b.search && b.pathname.indexOf(b.search) == -1 && (c += b.search), b.hostname != location.host && (c = "/external/" + b.hostname + c), _gaq.push(["_trackPageview", c]), _gaq.push(["b._trackPageview", c])
}

function initContent() {
    var a = $(this);
    $(window).on("load", function () {
        a.owlCarousel({
            items: 1,
            autoHeight: !0,
            loop: !1,
            nav: !0,
            navText: ['<span class="ca-gov-icon-arrow-prev" aria-hidden="true"></span>', '<span class="ca-gov-icon-arrow-next" aria-hidden="true"></span>'],
            dots: !0,
            onResized: function () {
                window.setTimeout(function () {
                    $(window).trigger("resize")
                }, 0)
            },
            onDragged: function () {
                window.setTimeout(function () {
                    $(window).trigger("resize")
                }, 0)
            },
            onTranslated: function () {
                window.setTimeout(function () {
                    $(window).trigger("resize")
                }, 0)
            }
        }), a.on("changed.owl.carousel", function (b) {
            setTimeout(function () {
                a.find(".owl-item.active .item video").each(function () {
                    $(this).get(0).play()
                })
            }, 10)
        })
    })
}

function breadcrumbs() {
    if ($(".breadcrumb.dynamic")[0]) {
        var a = location.href,
            b = a.indexOf("#");
        b != -1 && (a = a.substr(0, b));
        var b = a.indexOf("?");
        b != -1 && (a = a.substr(0, b)), a = unescape(a);
        var c = /<.*/g;
        a = a.replace(c, "");
        var d = a.split("/"),
            e = '<li><a href="/">Home</a></li>',
            f = "/";
        if (("" == d[d.length - 1] || d[d.length - 1].match(/^index\.|^default\./i)) && d.length-- , d.length > 3) {
            for (counter = 3; counter < d.length - 1; counter++) f += d[counter] + "/", e += '<li><a href="' + f + '">' + d[counter].replace(/(_|-)/g, " ") + "</a></li>";
            e += '<li class="active">' + d[d.length - 1].replace(/(_|-)/g, " ").replace(/\.\w{3,5}$/, "") + "</li>"
        }
        $(".breadcrumb.dynamic").html(e)
    }
}

function initServiceGroup() {
    var a = $(this),
        b = a.find(".service-tile");
    a.find(".service-tile-empty").on("click", function (a) {
        a.stopPropagation();
        var b = $(this).attr("data-url");
        window.location = b
    }), $(window).resize(function () {
        var d = $(window).width();
        d !== c && (__$currentRow && shrinkAndRemove(__$currentRow), initTiles(a, b), c = d)
    });
    var c = $(window).width();
    a.eqHeight(".service-tile"), a.on("more.new", function () {
        a.eqHeight(".service-tile"), $(window).trigger("resize"), b = a.find(".service-tile"), initTiles(a, b)
    }), b.find(".icon-fallback").each(setIconFallback), initTiles(a, b), setUpEvents(a)
}

function initTiles(a, b) {
    b.each(function () {
        setCloseClasses($(this))
    }), b.find(".icon-fallback").each(setIconFallback), b.find(".collapse").collapse(), a.find(".service-tile-full .container").css({
        height: ""
    })
}

function shrinkAndRemove(a) {
    a.animate({
        height: "0px"
    }, 300, "linear", function () {
        a.empty().remove()
    })
}

function setUpEvents(a) {
    function b(a) {
        var b = $(this);
        a.preventDefault();
        var c = findRow(b);
        shrinkAndRemove(c), setCloseClasses(b)
    }

    function c(c) {
        var d = $(this);
        c.preventDefault(), a.find(".service-tile").not(d).each(function () {
            var a = $(this);
            setCloseClasses(a)
        }), d.attr("data-state", "open");
        var e = findRow(d);
        checkIfOldAndSet(e), insertContent(e, d), setCloseButtonEvent(d, b)
    }
    a.on("click", ".service-tile", function (a) {
        if (a.preventDefault(), $(this).hasClass("touched")) return void $(this).removeClass("touched");
        var d = $(this).attr("data-state");
        switch (d) {
            case "closed":
            case "info":
                c.call(this, a);
                break;
            case "open":
                b.call(this, a)
        }
    })
}

function setIconFallback() {
    var a = $(this).width();
    $(this).css({
        "font-size": .6 * a
    })
}

function setCloseClasses(a) {
    a.attr("data-state", "closed").removeClass("show-info")
}

function setCloseButtonEvent(a, b) {
    var c = a.data("tile-id"),
        d = a.parent().find('.service-tile-panel[data-tile-id="' + c + '"]').first();
    d.find(".close.btn").on("click", function (c) {
        b.call(a, c)
    })
}

function insertContent(a, b) {
    if (a) {
        var c = b.data("tile-id"),
            d = b.parent().find('.service-tile-panel[data-tile-id="' + c + '"]').first();
        a.css("height", a.height() + "px"), a.empty(), d.clone().appendTo(a), a.animate({
            height: d.height() + "px"
        }, 300, "linear", function () {
            a.css("height", ""), scrollToEl(b)
        })
    }
}

function findRow(a) {
    var b = a.nextAll(".service-tile, .service-tile-full").filter(function () {
        return $(this).offset().top !== a.offset().top
    }).first();
    return b.is(".service-tile-full") ? b : b.is(".service-tile") ? createExpandedRow(b, "before") : a.nextAll(".service-tile").length ? createExpandedRow(a.nextAll(".service-tile").last(), "after") : createExpandedRow(a, "after")
}

function checkIfOldAndSet(a) {
    __$currentRow && !__$currentRow.is(a) && shrinkAndRemove(__$currentRow), __$currentRow = a
}

function createExpandedRow(a, b) {
    var c = $("<div>").addClass("service-tile-full");
    return a[b](c), c.focus(), c.addClass("is-open"), c
}

function scrollToEl(a) {
    if (a && a.length) {
        var b = a.offset().top;
        $("html, body").animate({
            scrollTop: b
        }, 450)
    }
}

function initCountUp() {
    var a = $(this),
        b = a.text().trim();
    a.text("0"), a.css({
        visibility: "visible"
    });
    var c = {
        useEasing: !0,
        useGrouping: !1,
        separator: "",
        decimal: ".",
        prefix: ""
    },
        d = 0;
    b.indexOf(".") !== -1 && (d = b.split(".")[1].length), b.indexOf(",") !== -1 && (c.useGrouping = !0, c.separator = ",", b = parseFloat(b.replace(/,/g, "")));
    var e = new CountUp(a.get(0), 0, b, d, 3.5, c);
    new Waypoint({
        element: a.get(0),
        offset: "100%",
        handler: function () {
            e.start()
        }
    })
}

function initPlotly(a, b) {
    var c = $(this);
    if ($("html").hasClass("ie8") || $("html").hasClass("ie7")) return void (c.has("img").length || c.html('<span class="plotly-chart--loading">Chart image not found</span>'));
    c.has("img").length || c.html('<span class="plotly-chart--loading">Loading</span>');
    var d = ["d3", "Plotly", "Float32Array" in window ? "" : "typedarray"];
    requirejs(d, function (a, b) {
        function f() {
            var a = c.attr("data-fixed-height") ? c.attr("data-fixed-height") + "px" : e + "%";
            return a
        }
        var d = 100,
            e = 100;
        c.empty();
        var g = a.select(c.get(0)).style({
            width: d + "%",
            "margin-left": (100 - d) / 2 + "%",
            height: f(),
            "margin-top": (100 - d) / 2 + "%"
        }),
            h = g.node(),
            i = c.attr("data-title"),
            j = c.attr("data-x-label"),
            k = c.attr("data-y-label");
        getConfig(a, c, function (a) {
            b.plot(h, a, {
                title: i,
                font: {
                    family: "Source Sans Pro, sans-serif",
                    size: 20,
                    color: "#333"
                },
                xaxis: {
                    title: j,
                    titlefont: {
                        family: "Source Sans Pro, sans-serif",
                        size: 18,
                        color: "#333"
                    }
                },
                yaxis: {
                    title: k,
                    titlefont: {
                        family: "Source Sans Pro, sans-serif",
                        size: 18,
                        color: "#333"
                    }
                }
            })
        }), $(window).resize(function () {
            a.select(c.get(0)).style({
                height: f()
            });
            b.Plots.resize(h)
        })
    })
}

function getConfigSkeleton(a) {
    switch (a) {
        case "bar":
            return defaultBar;
        case "pie":
            return defaultPie;
        case "line":
            return defaultLine;
        default:
            return []
    }
}

function getConfig(a, b, c) {
    var e = (b.attr("data-datasource-url"), b.attr("data-config-url")),
        f = b.attr("data-type"),
        g = b.attr("data-color");
    if (e) return void $.getJSON(e, c);
    var h = getConfigSkeleton(f),
        i = b.attr("data-x-values"),
        j = b.attr("data-y-values");
    switch (i = i ? i.split("|").map(function (a) {
        return isNaN(parseFloat(a)) ? a : +a
    }) : [], j = j ? j.split("|") : [], f) {
        case "line":
        case "bar":
            h[0].x = i, h[0].y = j.map(function (a) {
                return +a
            });
            break;
        case "pie":
            h[0].values = i, h[0].labels = j
    }
    switch (g || (g = "#046B99"), f) {
        case "line":
            h[0].line.color = a.rgb(g).toString();
            break;
        case "bar":
            h[0].marker.color = a.rgb(g).toString();
            break;
        case "pie":
            var k = a.hsl(g),
                l = a.hsl((k.h - 4 * i.length) % 360, k.s, k.l),
                m = a.scale.linear().domain(i).interpolate(a.interpolateHsl).range([k.toString(), l.toString()]),
                n = i.map(function (a) {
                    return m(a)
                });
            h[0].marker.colors = n
    }
    c(h)
}

function initStats() {
    var a = $(this),
        b = ["d3"];
    $("html").hasClass("ie8") || $("html").hasClass("ie7") || requirejs(b, function (b) {
        function k() {
            var b = e.get(0).clientWidth,
                d = (e.get(0).clientHeight, a.find(".small-goal-text"));
            parseFloat(a.find(".small-goal-text").css("line-height"));
            a.find(".info").css({
                top: -b / 4
            }), d.css({
                "font-size": b / 18
            });
            var g = d.height();
            d.css({
                top: b < 400 ? 2 * g + 20 : 1.5 * g
            }), a.find(".big-number").css({
                "font-size": b / 6
            }), a.find(".percent-detail").css({
                "font-size": b / 10
            })
        }
        var c = "right" == a.attr("data-direction"),
            d = parseFloat(a.attr("data-percentfill")),
            e = a.find(".half-gauge-chart"),
            f = a.attr("data-colorfill"),
            g = 0 != a.find(".small-goal-text").length,
            h = {
                bindTo: e.get(0),
                background: !0,
                maxValue: 100,
                startAngle: -90,
                endAngle: 90,
                thickness: 5,
                color: f,
                showHalfTick: g,
                size: {
                    width: e.get(0).clientWidth,
                    height: e.get(0).clientWidth
                },
                flipStart: c
            },
            i = initHalfDonut(b),
            j = new i(h);
        j.load({
            data: 0
        }), k(), $(window).resize(function () {
            window.setTimeout(function () {
                h.size = {
                    width: e.width(),
                    height: e.width()
                }, h.data = d, j = new i(h), j.load({
                    data: d
                }), k()
            }, 10)
        });
        new Waypoint({
            element: e.get(0),
            offset: "100%",
            handler: function () {
                j.load({
                    data: d
                })
            }
        })
    })
}

function initHalfDonut(a) {
    function d(a) {
        return a.config.thickness || a.config.radius
    }

    function e(b) {
        var c = j(b),
            d = k(b),
            e = "translate(" + c / 2 + "," + d / 2 + ")" + (1 == b.config.flipStart ? " scale(-1,1)" : ""),
            f = a.select(b.config.bindTo).select("svg");
        f.empty() ? b.svg = a.select(b.config.bindTo).append("svg").attr("class", b.config.classNames).attr("width", c).attr("height", d / 2).append("g").attr("transform", e) : (b.svg = a.select(b.config.bindTo).select("svg").attr("class", b.config.classNames).attr("width", c).attr("height", d / 2).select("g").attr("transform", e), b.svg.selectAll("*").remove()), b.config.background && b.svg.append("path").attr("class", "donut-background").transition().duration(0).attrTween("d", function (a, c) {
            var d = {
                value: 0,
                startAngle: l(b.config.startAngle),
                endAngle: l(b.config.endAngle)
            };
            return g.call(this, d, c, b)
        }), b.config.showHalfTick && b.svg.append("line").attr("class", "donut-halfmark").attr("stroke", "gray").attr("stroke-width", 1).attr({
            x1: 0,
            x2: 0,
            y1: -d / 2 + 10,
            y2: -d / 2 + 35
        })
    }

    function f(a) {
        var b = a.svg.selectAll("path.donut-section").data(a.data);
        b.enter().append("path").attr("class", function (a, b) {
            return "donut-section value-" + b
        }).attr("fill", a.config.color).attr("stroke", "#fff").attr("stroke-width", a.config.offset / 2), a.svg.selectAll("path.donut-section").transition().duration(2e3).attrTween("d", function (b, c) {
            return g.call(this, b, c, a)
        }), b.exit().transition().duration(100).attrTween("d", function (b, c) {
            return h.call(this, b, c, a)
        }).remove()
    }

    function g(b, c, d) {
        var e, f, g, h;
        return this._current || (e = d.svg.selectAll("path")[0][c - 1], f = e && e._current ? e._current.endAngle : l(d.config.startAngle), g = {
            startAngle: f,
            endAngle: f,
            value: 0
        }), h = a.interpolate(this._current || g, b), this._current = h(0),
            function (a) {
                return d.arc(h(a))
            }
    }

    function h(b, c, d) {
        var e = {
            startAngle: l(d.config.endAngle),
            endAngle: l(d.config.endAngle),
            value: 0
        },
            c = a.interpolate(b, e);
        return function (a) {
            return d.arc(c(a))
        }
    }

    function i(a) {
        var b = j(a) - a.config.margin.left - a.config.margin.right,
            c = k(a) - a.config.margin.top - a.config.margin.bottom;
        return Math.min(b, c) / 2
    }

    function j(a) {
        return a.config.size && a.config.size.width
    }

    function k(a) {
        return a.config.size && a.config.size.height
    }

    function l(a) {
        return a * (Math.PI / 180)
    }

    function n() {
        for (var a = 1; a < arguments.length; a++)
            for (var b in arguments[a]) arguments[a].hasOwnProperty(b) && (arguments[0][b] = arguments[a][b]);
        return arguments[0]
    }
    var b = {
        className: "donut",
        size: {
            width: 200,
            height: 200
        },
        margin: {
            top: 20,
            right: 20,
            bottom: 20,
            left: 20
        },
        startAngle: 0,
        endAngle: 360,
        thickness: null,
        offset: 0,
        sort: null,
        maxValue: null,
        background: !1,
        flipStart: !1,
        color: "rgb(49, 130, 189)",
        accessor: function (a, b) {
            return a
        }
    },
        c = function (c) {
            this.config = n({}, b, c), this.config.radius = i(this), this.accessor = this.config.accessor, this.pie = a.layout.pie().sort(this.config.sort).startAngle(l(this.config.startAngle)).endAngle(l(this.config.endAngle)), this.accessor && "function" == typeof this.accessor && this.pie.value(this.accessor);
            var f = d(this);
            this.arc = a.svg.arc().innerRadius(this.config.radius - f - this.config.offset / 4).outerRadius(this.config.radius + this.config.offset / 4), e(this)
        };
    return c.prototype.load = function (a) {
        var b = a && null != a.data ? a.data : this.data.map(this.accessor);
        b = Array.isArray(b) ? b : [b], this.config.maxValue ? this.data = this.pieMaxValue(b) : this.data = this.pie(b), f(this)
    }, c.prototype.pieMaxValue = function (b) {
        var c = this.accessor,
            d = this,
            e = b.map(function (a, b) {
                return +c.call(d, a, b)
            }),
            f = a.sum(e),
            g = a.max([this.config.maxValue, f]),
            h = g - f,
            i = +l(this.config.startAngle),
            j = (l(this.config.endAngle) - i) / (f + h),
            k = a.range(b.length),
            m = [];
        return k.forEach(function (a) {
            var c;
            m[a] = {
                data: b[a],
                value: c = e[a],
                startAngle: i,
                endAngle: i += c * j
            }
        }), m
    }, c
}

function initAnimations() {
    var a = $(this);
    new Waypoint({
        element: a.get(0),
        offset: "95%",
        handler: function () {
            return; //hotfix
            var b = a.attr("class").match(/animate-(\w+)\b/i)[1];
            a.removeClass("animate-" + b), a.addClass("animated " + b), this.disable()
        }
    })
}

function makeBlur(a) {
    a.Vague({
        intensity: 6
    }).blur()
}

function initLoad() {
    function f(c) {
        $(d).load(c, function (c, d, f) {
            var g = f.getResponseHeader("Link");
            e || ("error" == d || null == g ? a.animate({
                opacity: 0,
                height: 0
            }, 300, "linear") : b = g.match(/<(.*?)>/)[1])
        })
    }
    var a = $(this),
        b = a.attr("data-ajax-target"),
        c = a.attr("data-container-target"),
        d = a.find(".more-content"),
        e = a.attr("data-ajax-test");
    makeBlur(d), f(b), a.on("click", function (a) {
        a.preventDefault(), $(d).children().hide().appendTo(c).fadeIn(1e3), $(c).trigger("more.new"), f(b)
    })
} + function (a) {
    "use strict";

    function d(b) {
        return this.each(function () {
            var d = a(this),
                e = d.data("bs.alert");
            e || d.data("bs.alert", e = new c(this)), "string" == typeof b && e[b].call(d)
        })
    }
    var b = '[data-dismiss="alert"]',
        c = function (c) {
            a(c).on("click", b, this.close)
        };
    c.VERSION = "3.3.5", c.TRANSITION_DURATION = 150, c.prototype.close = function (b) {
        function g() {
            f.detach().trigger("closed.bs.alert").remove()
        }
        var d = a(this),
            e = d.attr("data-target");
        e || (e = d.attr("href"), e = e && e.replace(/.*(?=#[^\s]*$)/, ""));
        var f = a(e);
        b && b.preventDefault(), f.length || (f = d.closest(".alert")), f.trigger(b = a.Event("close.bs.alert")), b.isDefaultPrevented() || (f.removeClass("in"), a.support.transition && f.hasClass("fade") ? f.one("bsTransitionEnd", g).emulateTransitionEnd(c.TRANSITION_DURATION) : g())
    };
    var e = a.fn.alert;
    a.fn.alert = d, a.fn.alert.Constructor = c, a.fn.alert.noConflict = function () {
        return a.fn.alert = e, this
    }, a(document).on("click.bs.alert.data-api", b, c.prototype.close)
}(jQuery), + function (a) {
    "use strict";

    function c(c) {
        return this.each(function () {
            var d = a(this),
                e = d.data("bs.button"),
                f = "object" == typeof c && c;
            e || d.data("bs.button", e = new b(this, f)), "toggle" == c ? e.toggle() : c && e.setState(c)
        })
    }
    var b = function (c, d) {
        this.$element = a(c), this.options = a.extend({}, b.DEFAULTS, d), this.isLoading = !1
    };
    b.VERSION = "3.3.5", b.DEFAULTS = {
        loadingText: "loading..."
    }, b.prototype.setState = function (b) {
        var c = "disabled",
            d = this.$element,
            e = d.is("input") ? "val" : "html",
            f = d.data();
        b += "Text", null == f.resetText && d.data("resetText", d[e]()), setTimeout(a.proxy(function () {
            d[e](null == f[b] ? this.options[b] : f[b]), "loadingText" == b ? (this.isLoading = !0, d.addClass(c).attr(c, c)) : this.isLoading && (this.isLoading = !1, d.removeClass(c).removeAttr(c))
        }, this), 0)
    }, b.prototype.toggle = function () {
        var a = !0,
            b = this.$element.closest('[data-toggle="buttons"]');
        if (b.length) {
            var c = this.$element.find("input");
            "radio" == c.prop("type") ? (c.prop("checked") && (a = !1), b.find(".active").removeClass("active"), this.$element.addClass("active")) : "checkbox" == c.prop("type") && (c.prop("checked") !== this.$element.hasClass("active") && (a = !1), this.$element.toggleClass("active")), c.prop("checked", this.$element.hasClass("active")), a && c.trigger("change")
        } else this.$element.attr("aria-pressed", !this.$element.hasClass("active")), this.$element.toggleClass("active")
    };
    var d = a.fn.button;
    a.fn.button = c, a.fn.button.Constructor = b, a.fn.button.noConflict = function () {
        return a.fn.button = d, this
    }, a(document).on("click.bs.button.data-api", '[data-toggle^="button"]', function (b) {
        var d = a(b.target);
        d.hasClass("btn") || (d = d.closest(".btn")), c.call(d, "toggle"), a(b.target).is('input[type="radio"]') || a(b.target).is('input[type="checkbox"]') || b.preventDefault()
    }).on("focus.bs.button.data-api blur.bs.button.data-api", '[data-toggle^="button"]', function (b) {
        a(b.target).closest(".btn").toggleClass("focus", /^focus(in)?$/.test(b.type))
    })
}(jQuery), + function (a) {
    "use strict";

    function c(b) {
        var c, d = b.attr("data-target") || (c = b.attr("href")) && c.replace(/.*(?=#[^\s]+$)/, "");
        return a(d)
    }

    function d(c) {
        return this.each(function () {
            var d = a(this),
                e = d.data("bs.collapse"),
                f = a.extend({}, b.DEFAULTS, d.data(), "object" == typeof c && c);
            !e && f.toggle && /show|hide/.test(c) && (f.toggle = !1), e || d.data("bs.collapse", e = new b(this, f)), "string" == typeof c && e[c]()
        })
    }
    var b = function (c, d) {
        this.$element = a(c), this.options = a.extend({}, b.DEFAULTS, d), this.$trigger = a('[data-toggle="collapse"][href="#' + c.id + '"],[data-toggle="collapse"][data-target="#' + c.id + '"]'), this.transitioning = null, this.options.parent ? this.$parent = this.getParent() : this.addAriaAndCollapsedClass(this.$element, this.$trigger), this.options.toggle && this.toggle()
    };
    b.VERSION = "3.3.5", b.TRANSITION_DURATION = 350, b.DEFAULTS = {
        toggle: !0
    }, b.prototype.dimension = function () {
        var a = this.$element.hasClass("width");
        return a ? "width" : "height"
    }, b.prototype.show = function () {
        if (!this.transitioning && !this.$element.hasClass("in")) {
            var c, e = this.$parent && this.$parent.children(".panel").children(".in, .collapsing");
            if (!(e && e.length && (c = e.data("bs.collapse"), c && c.transitioning))) {
                var f = a.Event("show.bs.collapse");
                if (this.$element.trigger(f), !f.isDefaultPrevented()) {
                    e && e.length && (d.call(e, "hide"), c || e.data("bs.collapse", null));
                    var g = this.dimension();
                    this.$element.removeClass("collapse").addClass("collapsing")[g](0).attr("aria-expanded", !0), this.$trigger.removeClass("collapsed").attr("aria-expanded", !0), this.transitioning = 1;
                    var h = function () {
                        this.$element.removeClass("collapsing").addClass("collapse in")[g](""), this.transitioning = 0, this.$element.trigger("shown.bs.collapse")
                    };
                    if (!a.support.transition) return h.call(this);
                    var i = a.camelCase(["scroll", g].join("-"));
                    this.$element.one("bsTransitionEnd", a.proxy(h, this)).emulateTransitionEnd(b.TRANSITION_DURATION)[g](this.$element[0][i])
                }
            }
        }
    }, b.prototype.hide = function () {
        if (!this.transitioning && this.$element.hasClass("in")) {
            var c = a.Event("hide.bs.collapse");
            if (this.$element.trigger(c), !c.isDefaultPrevented()) {
                var d = this.dimension();
                this.$element[d](this.$element[d]())[0].offsetHeight, this.$element.addClass("collapsing").removeClass("collapse in").attr("aria-expanded", !1), this.$trigger.addClass("collapsed").attr("aria-expanded", !1), this.transitioning = 1;
                var e = function () {
                    this.transitioning = 0, this.$element.removeClass("collapsing").addClass("collapse").trigger("hidden.bs.collapse")
                };
                return a.support.transition ? void this.$element[d](0).one("bsTransitionEnd", a.proxy(e, this)).emulateTransitionEnd(b.TRANSITION_DURATION) : e.call(this)
            }
        }
    }, b.prototype.toggle = function () {
        this[this.$element.hasClass("in") ? "hide" : "show"]()
    }, b.prototype.getParent = function () {
        return a(this.options.parent).find('[data-toggle="collapse"][data-parent="' + this.options.parent + '"]').each(a.proxy(function (b, d) {
            var e = a(d);
            this.addAriaAndCollapsedClass(c(e), e)
        }, this)).end()
    }, b.prototype.addAriaAndCollapsedClass = function (a, b) {
        var c = a.hasClass("in");
        a.attr("aria-expanded", c), b.toggleClass("collapsed", !c).attr("aria-expanded", c)
    };
    var e = a.fn.collapse;
    a.fn.collapse = d, a.fn.collapse.Constructor = b, a.fn.collapse.noConflict = function () {
        return a.fn.collapse = e, this
    }, a(document).on("click.bs.collapse.data-api", '[data-toggle="collapse"]', function (b) {
        var e = a(this);
        e.attr("data-target") || b.preventDefault();
        var f = c(e),
            g = f.data("bs.collapse"),
            h = g ? "toggle" : e.data();
        d.call(f, h)
    })
}(jQuery), + function (a) {
    "use strict";

    function e(b) {
        var c = b.attr("data-target");
        c || (c = b.attr("href"), c = c && /#[A-Za-z]/.test(c) && c.replace(/.*(?=#[^\s]*$)/, ""));
        var d = c && a(c);
        return d && d.length ? d : b.parent()
    }

    function f(d) {
        d && 3 === d.which || (a(b).remove(), a(c).each(function () {
            var b = a(this),
                c = e(b),
                f = {
                    relatedTarget: this
                };
            c.hasClass("open") && (d && "click" == d.type && /input|textarea/i.test(d.target.tagName) && a.contains(c[0], d.target) || (c.trigger(d = a.Event("hide.bs.dropdown", f)), d.isDefaultPrevented() || (b.attr("aria-expanded", "false"), c.removeClass("open").trigger("hidden.bs.dropdown", f))))
        }))
    }

    function g(b) {
        return this.each(function () {
            var c = a(this),
                e = c.data("bs.dropdown");
            e || c.data("bs.dropdown", e = new d(this)), "string" == typeof b && e[b].call(c)
        })
    }
    var b = ".dropdown-backdrop",
        c = '[data-toggle="dropdown"]',
        d = function (b) {
            a(b).on("click.bs.dropdown", this.toggle)
        };
    d.VERSION = "3.3.5", d.prototype.toggle = function (b) {
        var c = a(this);
        if (!c.is(".disabled, :disabled")) {
            var d = e(c),
                g = d.hasClass("open");
            if (f(), !g) {
                "ontouchstart" in document.documentElement && !d.closest(".navbar-nav").length && a(document.createElement("div")).addClass("dropdown-backdrop").insertAfter(a(this)).on("click", f);
                var h = {
                    relatedTarget: this
                };
                if (d.trigger(b = a.Event("show.bs.dropdown", h)), b.isDefaultPrevented()) return;
                c.trigger("focus").attr("aria-expanded", "true"), d.toggleClass("open").trigger("shown.bs.dropdown", h)
            }
            return !1
        }
    }, d.prototype.keydown = function (b) {
        if (/(38|40|27|32)/.test(b.which) && !/input|textarea/i.test(b.target.tagName)) {
            var d = a(this);
            if (b.preventDefault(), b.stopPropagation(), !d.is(".disabled, :disabled")) {
                var f = e(d),
                    g = f.hasClass("open");
                if (!g && 27 != b.which || g && 27 == b.which) return 27 == b.which && f.find(c).trigger("focus"), d.trigger("click");
                var h = " li:not(.disabled):visible a",
                    i = f.find(".dropdown-menu" + h);
                if (i.length) {
                    var j = i.index(b.target);
                    38 == b.which && j > 0 && j-- , 40 == b.which && j < i.length - 1 && j++ , ~j || (j = 0), i.eq(j).trigger("focus")
                }
            }
        }
    };
    var h = a.fn.dropdown;
    a.fn.dropdown = g, a.fn.dropdown.Constructor = d, a.fn.dropdown.noConflict = function () {
        return a.fn.dropdown = h, this
    }, a(document).on("click.bs.dropdown.data-api", f).on("click.bs.dropdown.data-api", ".dropdown form", function (a) {
        a.stopPropagation()
    }).on("click.bs.dropdown.data-api", c, d.prototype.toggle).on("keydown.bs.dropdown.data-api", c, d.prototype.keydown).on("keydown.bs.dropdown.data-api", ".dropdown-menu", d.prototype.keydown)
}(jQuery), + function (a) {
    "use strict";

    function c(c, d) {
        return this.each(function () {
            var e = a(this),
                f = e.data("bs.modal"),
                g = a.extend({}, b.DEFAULTS, e.data(), "object" == typeof c && c);
            f || e.data("bs.modal", f = new b(this, g)), "string" == typeof c ? f[c](d) : g.show && f.show(d)
        })
    }
    var b = function (b, c) {
        this.options = c, this.$body = a(document.body), this.$element = a(b), this.$dialog = this.$element.find(".modal-dialog"), this.$backdrop = null, this.isShown = null, this.originalBodyPad = null, this.scrollbarWidth = 0, this.ignoreBackdropClick = !1, this.options.remote && this.$element.find(".modal-content").load(this.options.remote, a.proxy(function () {
            this.$element.trigger("loaded.bs.modal")
        }, this))
    };
    b.VERSION = "3.3.5", b.TRANSITION_DURATION = 300, b.BACKDROP_TRANSITION_DURATION = 150, b.DEFAULTS = {
        backdrop: !0,
        keyboard: !0,
        show: !0
    }, b.prototype.toggle = function (a) {
        return this.isShown ? this.hide() : this.show(a)
    }, b.prototype.show = function (c) {
        var d = this,
            e = a.Event("show.bs.modal", {
                relatedTarget: c
            });
        this.$element.trigger(e), this.isShown || e.isDefaultPrevented() || (this.isShown = !0, this.checkScrollbar(), this.setScrollbar(), this.$body.addClass("modal-open"), this.escape(), this.resize(), this.$element.on("click.dismiss.bs.modal", '[data-dismiss="modal"]', a.proxy(this.hide, this)), this.$dialog.on("mousedown.dismiss.bs.modal", function () {
            d.$element.one("mouseup.dismiss.bs.modal", function (b) {
                a(b.target).is(d.$element) && (d.ignoreBackdropClick = !0)
            })
        }), this.backdrop(function () {
            var e = a.support.transition && d.$element.hasClass("fade");
            d.$element.parent().length || d.$element.appendTo(d.$body), d.$element.show().scrollTop(0), d.adjustDialog(), e && d.$element[0].offsetWidth, d.$element.addClass("in"), d.enforceFocus();
            var f = a.Event("shown.bs.modal", {
                relatedTarget: c
            });
            e ? d.$dialog.one("bsTransitionEnd", function () {
                d.$element.trigger("focus").trigger(f)
            }).emulateTransitionEnd(b.TRANSITION_DURATION) : d.$element.trigger("focus").trigger(f)
        }))
    }, b.prototype.hide = function (c) {
        c && c.preventDefault(), c = a.Event("hide.bs.modal"), this.$element.trigger(c), this.isShown && !c.isDefaultPrevented() && (this.isShown = !1, this.escape(), this.resize(), a(document).off("focusin.bs.modal"), this.$element.removeClass("in").off("click.dismiss.bs.modal").off("mouseup.dismiss.bs.modal"), this.$dialog.off("mousedown.dismiss.bs.modal"), a.support.transition && this.$element.hasClass("fade") ? this.$element.one("bsTransitionEnd", a.proxy(this.hideModal, this)).emulateTransitionEnd(b.TRANSITION_DURATION) : this.hideModal())
    }, b.prototype.enforceFocus = function () {
        a(document).off("focusin.bs.modal").on("focusin.bs.modal", a.proxy(function (a) {
            this.$element[0] === a.target || this.$element.has(a.target).length || this.$element.trigger("focus")
        }, this))
    }, b.prototype.escape = function () {
        this.isShown && this.options.keyboard ? this.$element.on("keydown.dismiss.bs.modal", a.proxy(function (a) {
            27 == a.which && this.hide()
        }, this)) : this.isShown || this.$element.off("keydown.dismiss.bs.modal")
    }, b.prototype.resize = function () {
        this.isShown ? a(window).on("resize.bs.modal", a.proxy(this.handleUpdate, this)) : a(window).off("resize.bs.modal")
    }, b.prototype.hideModal = function () {
        var a = this;
        this.$element.hide(), this.backdrop(function () {
            a.$body.removeClass("modal-open"), a.resetAdjustments(), a.resetScrollbar(), a.$element.trigger("hidden.bs.modal")
        })
    }, b.prototype.removeBackdrop = function () {
        this.$backdrop && this.$backdrop.remove(), this.$backdrop = null
    }, b.prototype.backdrop = function (c) {
        var d = this,
            e = this.$element.hasClass("fade") ? "fade" : "";
        if (this.isShown && this.options.backdrop) {
            var f = a.support.transition && e;
            if (this.$backdrop = a(document.createElement("div")).addClass("modal-backdrop " + e).appendTo(this.$body), this.$element.on("click.dismiss.bs.modal", a.proxy(function (a) {
                return this.ignoreBackdropClick ? void (this.ignoreBackdropClick = !1) : void (a.target === a.currentTarget && ("static" == this.options.backdrop ? this.$element[0].focus() : this.hide()))
            }, this)), f && this.$backdrop[0].offsetWidth, this.$backdrop.addClass("in"), !c) return;
            f ? this.$backdrop.one("bsTransitionEnd", c).emulateTransitionEnd(b.BACKDROP_TRANSITION_DURATION) : c()
        } else if (!this.isShown && this.$backdrop) {
            this.$backdrop.removeClass("in");
            var g = function () {
                d.removeBackdrop(), c && c()
            };
            a.support.transition && this.$element.hasClass("fade") ? this.$backdrop.one("bsTransitionEnd", g).emulateTransitionEnd(b.BACKDROP_TRANSITION_DURATION) : g()
        } else c && c()
    }, b.prototype.handleUpdate = function () {
        this.adjustDialog()
    }, b.prototype.adjustDialog = function () {
        var a = this.$element[0].scrollHeight > document.documentElement.clientHeight;
        this.$element.css({
            paddingLeft: !this.bodyIsOverflowing && a ? this.scrollbarWidth : "",
            paddingRight: this.bodyIsOverflowing && !a ? this.scrollbarWidth : ""
        })
    }, b.prototype.resetAdjustments = function () {
        this.$element.css({
            paddingLeft: "",
            paddingRight: ""
        })
    }, b.prototype.checkScrollbar = function () {
        var a = window.innerWidth;
        if (!a) {
            var b = document.documentElement.getBoundingClientRect();
            a = b.right - Math.abs(b.left)
        }
        this.bodyIsOverflowing = document.body.clientWidth < a, this.scrollbarWidth = this.measureScrollbar()
    }, b.prototype.setScrollbar = function () {
        var a = parseInt(this.$body.css("padding-right") || 0, 10);
        this.originalBodyPad = document.body.style.paddingRight || "", this.bodyIsOverflowing && this.$body.css("padding-right", a + this.scrollbarWidth)
    }, b.prototype.resetScrollbar = function () {
        this.$body.css("padding-right", this.originalBodyPad)
    }, b.prototype.measureScrollbar = function () {
        var a = document.createElement("div");
        a.className = "modal-scrollbar-measure", this.$body.append(a);
        var b = a.offsetWidth - a.clientWidth;
        return this.$body[0].removeChild(a), b
    };
    var d = a.fn.modal;
    a.fn.modal = c, a.fn.modal.Constructor = b, a.fn.modal.noConflict = function () {
        return a.fn.modal = d, this
    }, a(document).on("click.bs.modal.data-api", '[data-toggle="modal"]', function (b) {
        var d = a(this),
            e = d.attr("href"),
            f = a(d.attr("data-target") || e && e.replace(/.*(?=#[^\s]+$)/, "")),
            g = f.data("bs.modal") ? "toggle" : a.extend({
                remote: !/#/.test(e) && e
            }, f.data(), d.data());
        d.is("a") && b.preventDefault(), f.one("show.bs.modal", function (a) {
            a.isDefaultPrevented() || f.one("hidden.bs.modal", function () {
                d.is(":visible") && d.trigger("focus")
            })
        }), c.call(f, g, this)
    })
}(jQuery), + function (a) {
    "use strict";

    function c(c) {
        return this.each(function () {
            var d = a(this),
                e = d.data("bs.tab");
            e || d.data("bs.tab", e = new b(this)), "string" == typeof c && e[c]()
        })
    }
    var b = function (b) {
        this.element = a(b)
    };
    b.VERSION = "3.3.5", b.TRANSITION_DURATION = 150, b.prototype.show = function () {
        var b = this.element,
            c = b.closest("ul:not(.dropdown-menu)"),
            d = b.data("target");
        if (d || (d = b.attr("href"), d = d && d.replace(/.*(?=#[^\s]*$)/, "")), !b.parent("li").hasClass("active")) {
            var e = c.find(".active:last a"),
                f = a.Event("hide.bs.tab", {
                    relatedTarget: b[0]
                }),
                g = a.Event("show.bs.tab", {
                    relatedTarget: e[0]
                });
            if (e.trigger(f), b.trigger(g), !g.isDefaultPrevented() && !f.isDefaultPrevented()) {
                var h = a(d);
                this.activate(b.closest("li"), c), this.activate(h, h.parent(), function () {
                    e.trigger({
                        type: "hidden.bs.tab",
                        relatedTarget: b[0]
                    }), b.trigger({
                        type: "shown.bs.tab",
                        relatedTarget: e[0]
                    })
                })
            }
        }
    }, b.prototype.activate = function (c, d, e) {
        function h() {
            f.removeClass("active").find("> .dropdown-menu > .active").removeClass("active").end().find('[data-toggle="tab"]').attr("aria-expanded", !1), c.addClass("active").find('[data-toggle="tab"]').attr("aria-expanded", !0), g ? (c[0].offsetWidth, c.addClass("in")) : c.removeClass("fade"), c.parent(".dropdown-menu").length && c.closest("li.dropdown").addClass("active").end().find('[data-toggle="tab"]').attr("aria-expanded", !0), e && e()
        }
        var f = d.find("> .active"),
            g = e && a.support.transition && (f.length && f.hasClass("fade") || !!d.find("> .fade").length);
        f.length && g ? f.one("bsTransitionEnd", h).emulateTransitionEnd(b.TRANSITION_DURATION) : h(), f.removeClass("in")
    };
    var d = a.fn.tab;
    a.fn.tab = c, a.fn.tab.Constructor = b, a.fn.tab.noConflict = function () {
        return a.fn.tab = d, this
    };
    var e = function (b) {
        b.preventDefault(), c.call(a(this), "show")
    };
    a(document).on("click.bs.tab.data-api", '[data-toggle="tab"]', e).on("click.bs.tab.data-api", '[data-toggle="pill"]', e)
}(jQuery), + function (a) {
    "use strict";

    function b() {
        var a = document.createElement("bootstrap"),
            b = {
                WebkitTransition: "webkitTransitionEnd",
                MozTransition: "transitionend",
                OTransition: "oTransitionEnd otransitionend",
                transition: "transitionend"
            };
        for (var c in b)
            if (void 0 !== a.style[c]) return {
                end: b[c]
            };
        return !1
    }
    a.fn.emulateTransitionEnd = function (b) {
        var c = !1,
            d = this;
        a(this).one("bsTransitionEnd", function () {
            c = !0
        });
        var e = function () {
            c || a(d).trigger(a.support.transition.end)
        };
        return setTimeout(e, b), this
    }, a(function () {
        a.support.transition = b(), a.support.transition && (a.event.special.bsTransitionEnd = {
            bindType: a.support.transition.end,
            delegateType: a.support.transition.end,
            handle: function (b) {
                if (a(b.target).is(this)) return b.handleObj.handler.apply(this, arguments)
            }
        })
    })
}(jQuery), + function (a) {
    "use strict";

    function c(c) {
        return this.each(function () {
            var d = a(this),
                e = d.data("bs.tooltip"),
                f = "object" == typeof c && c;
            !e && /destroy|hide/.test(c) || (e || d.data("bs.tooltip", e = new b(this, f)), "string" == typeof c && e[c]())
        })
    }
    var b = function (a, b) {
        this.type = null, this.options = null, this.enabled = null, this.timeout = null, this.hoverState = null, this.$element = null, this.inState = null, this.init("tooltip", a, b)
    };
    b.VERSION = "3.3.5", b.TRANSITION_DURATION = 150, b.DEFAULTS = {
        animation: !0,
        placement: "top",
        selector: !1,
        template: '<div class="tooltip" role="tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>',
        trigger: "hover focus",
        title: "",
        delay: 0,
        html: !1,
        container: !1,
        viewport: {
            selector: "body",
            padding: 0
        }
    }, b.prototype.init = function (b, c, d) {
        if (this.enabled = !0, this.type = b, this.$element = a(c), this.options = this.getOptions(d), this.$viewport = this.options.viewport && a(a.isFunction(this.options.viewport) ? this.options.viewport.call(this, this.$element) : this.options.viewport.selector || this.options.viewport), this.inState = {
            click: !1,
            hover: !1,
            focus: !1
        }, this.$element[0] instanceof document.constructor && !this.options.selector) throw new Error("`selector` option must be specified when initializing " + this.type + " on the window.document object!");
        for (var e = this.options.trigger.split(" "), f = e.length; f--;) {
            var g = e[f];
            if ("click" == g) this.$element.on("click." + this.type, this.options.selector, a.proxy(this.toggle, this));
            else if ("manual" != g) {
                var h = "hover" == g ? "mouseenter" : "focusin",
                    i = "hover" == g ? "mouseleave" : "focusout";
                this.$element.on(h + "." + this.type, this.options.selector, a.proxy(this.enter, this)),
                    this.$element.on(i + "." + this.type, this.options.selector, a.proxy(this.leave, this))
            }
        }
        this.options.selector ? this._options = a.extend({}, this.options, {
            trigger: "manual",
            selector: ""
        }) : this.fixTitle()
    }, b.prototype.getDefaults = function () {
        return b.DEFAULTS
    }, b.prototype.getOptions = function (b) {
        return b = a.extend({}, this.getDefaults(), this.$element.data(), b), b.delay && "number" == typeof b.delay && (b.delay = {
            show: b.delay,
            hide: b.delay
        }), b
    }, b.prototype.getDelegateOptions = function () {
        var b = {},
            c = this.getDefaults();
        return this._options && a.each(this._options, function (a, d) {
            c[a] != d && (b[a] = d)
        }), b
    }, b.prototype.enter = function (b) {
        var c = b instanceof this.constructor ? b : a(b.currentTarget).data("bs." + this.type);
        return c || (c = new this.constructor(b.currentTarget, this.getDelegateOptions()), a(b.currentTarget).data("bs." + this.type, c)), b instanceof a.Event && (c.inState["focusin" == b.type ? "focus" : "hover"] = !0), c.tip().hasClass("in") || "in" == c.hoverState ? void (c.hoverState = "in") : (clearTimeout(c.timeout), c.hoverState = "in", c.options.delay && c.options.delay.show ? void (c.timeout = setTimeout(function () {
            "in" == c.hoverState && c.show()
        }, c.options.delay.show)) : c.show())
    }, b.prototype.isInStateTrue = function () {
        for (var a in this.inState)
            if (this.inState[a]) return !0;
        return !1
    }, b.prototype.leave = function (b) {
        var c = b instanceof this.constructor ? b : a(b.currentTarget).data("bs." + this.type);
        if (c || (c = new this.constructor(b.currentTarget, this.getDelegateOptions()), a(b.currentTarget).data("bs." + this.type, c)), b instanceof a.Event && (c.inState["focusout" == b.type ? "focus" : "hover"] = !1), !c.isInStateTrue()) return clearTimeout(c.timeout), c.hoverState = "out", c.options.delay && c.options.delay.hide ? void (c.timeout = setTimeout(function () {
            "out" == c.hoverState && c.hide()
        }, c.options.delay.hide)) : c.hide()
    }, b.prototype.show = function () {
        var c = a.Event("show.bs." + this.type);
        if (this.hasContent() && this.enabled) {
            this.$element.trigger(c);
            var d = a.contains(this.$element[0].ownerDocument.documentElement, this.$element[0]);
            if (c.isDefaultPrevented() || !d) return;
            var e = this,
                f = this.tip(),
                g = this.getUID(this.type);
            this.setContent(), f.attr("id", g), this.$element.attr("aria-describedby", g), this.options.animation && f.addClass("fade");
            var h = "function" == typeof this.options.placement ? this.options.placement.call(this, f[0], this.$element[0]) : this.options.placement,
                i = /\s?auto?\s?/i,
                j = i.test(h);
            j && (h = h.replace(i, "") || "top"), f.detach().css({
                top: 0,
                left: 0,
                display: "block"
            }).addClass(h).data("bs." + this.type, this), this.options.container ? f.appendTo(this.options.container) : f.insertAfter(this.$element), this.$element.trigger("inserted.bs." + this.type);
            var k = this.getPosition(),
                l = f[0].offsetWidth,
                m = f[0].offsetHeight;
            if (j) {
                var n = h,
                    o = this.getPosition(this.$viewport);
                h = "bottom" == h && k.bottom + m > o.bottom ? "top" : "top" == h && k.top - m < o.top ? "bottom" : "right" == h && k.right + l > o.width ? "left" : "left" == h && k.left - l < o.left ? "right" : h, f.removeClass(n).addClass(h)
            }
            var p = this.getCalculatedOffset(h, k, l, m);
            this.applyPlacement(p, h);
            var q = function () {
                var a = e.hoverState;
                e.$element.trigger("shown.bs." + e.type), e.hoverState = null, "out" == a && e.leave(e)
            };
            a.support.transition && this.$tip.hasClass("fade") ? f.one("bsTransitionEnd", q).emulateTransitionEnd(b.TRANSITION_DURATION) : q()
        }
    }, b.prototype.applyPlacement = function (b, c) {
        var d = this.tip(),
            e = d[0].offsetWidth,
            f = d[0].offsetHeight,
            g = parseInt(d.css("margin-top"), 10),
            h = parseInt(d.css("margin-left"), 10);
        isNaN(g) && (g = 0), isNaN(h) && (h = 0), b.top += g, b.left += h, a.offset.setOffset(d[0], a.extend({
            using: function (a) {
                d.css({
                    top: Math.round(a.top),
                    left: Math.round(a.left)
                })
            }
        }, b), 0), d.addClass("in");
        var i = d[0].offsetWidth,
            j = d[0].offsetHeight;
        "top" == c && j != f && (b.top = b.top + f - j);
        var k = this.getViewportAdjustedDelta(c, b, i, j);
        k.left ? b.left += k.left : b.top += k.top;
        var l = /top|bottom/.test(c),
            m = l ? 2 * k.left - e + i : 2 * k.top - f + j,
            n = l ? "offsetWidth" : "offsetHeight";
        d.offset(b), this.replaceArrow(m, d[0][n], l)
    }, b.prototype.replaceArrow = function (a, b, c) {
        this.arrow().css(c ? "left" : "top", 50 * (1 - a / b) + "%").css(c ? "top" : "left", "")
    }, b.prototype.setContent = function () {
        var a = this.tip(),
            b = this.getTitle();
        a.find(".tooltip-inner")[this.options.html ? "html" : "text"](b), a.removeClass("fade in top bottom left right")
    }, b.prototype.hide = function (c) {
        function g() {
            "in" != d.hoverState && e.detach(), d.$element.removeAttr("aria-describedby").trigger("hidden.bs." + d.type), c && c()
        }
        var d = this,
            e = a(this.$tip),
            f = a.Event("hide.bs." + this.type);
        if (this.$element.trigger(f), !f.isDefaultPrevented()) return e.removeClass("in"), a.support.transition && e.hasClass("fade") ? e.one("bsTransitionEnd", g).emulateTransitionEnd(b.TRANSITION_DURATION) : g(), this.hoverState = null, this
    }, b.prototype.fixTitle = function () {
        var a = this.$element;
        (a.attr("title") || "string" != typeof a.attr("data-original-title")) && a.attr("data-original-title", a.attr("title") || "").attr("title", "")
    }, b.prototype.hasContent = function () {
        return this.getTitle()
    }, b.prototype.getPosition = function (b) {
        b = b || this.$element;
        var c = b[0],
            d = "BODY" == c.tagName,
            e = c.getBoundingClientRect();
        null == e.width && (e = a.extend({}, e, {
            width: e.right - e.left,
            height: e.bottom - e.top
        }));
        var f = d ? {
            top: 0,
            left: 0
        } : b.offset(),
            g = {
                scroll: d ? document.documentElement.scrollTop || document.body.scrollTop : b.scrollTop()
            },
            h = d ? {
                width: a(window).width(),
                height: a(window).height()
            } : null;
        return a.extend({}, e, g, h, f)
    }, b.prototype.getCalculatedOffset = function (a, b, c, d) {
        return "bottom" == a ? {
            top: b.top + b.height,
            left: b.left + b.width / 2 - c / 2
        } : "top" == a ? {
            top: b.top - d,
            left: b.left + b.width / 2 - c / 2
        } : "left" == a ? {
            top: b.top + b.height / 2 - d / 2,
            left: b.left - c
        } : {
                        top: b.top + b.height / 2 - d / 2,
                        left: b.left + b.width
                    }
    }, b.prototype.getViewportAdjustedDelta = function (a, b, c, d) {
        var e = {
            top: 0,
            left: 0
        };
        if (!this.$viewport) return e;
        var f = this.options.viewport && this.options.viewport.padding || 0,
            g = this.getPosition(this.$viewport);
        if (/right|left/.test(a)) {
            var h = b.top - f - g.scroll,
                i = b.top + f - g.scroll + d;
            h < g.top ? e.top = g.top - h : i > g.top + g.height && (e.top = g.top + g.height - i)
        } else {
            var j = b.left - f,
                k = b.left + f + c;
            j < g.left ? e.left = g.left - j : k > g.right && (e.left = g.left + g.width - k)
        }
        return e
    }, b.prototype.getTitle = function () {
        var a, b = this.$element,
            c = this.options;
        return a = b.attr("data-original-title") || ("function" == typeof c.title ? c.title.call(b[0]) : c.title)
    }, b.prototype.getUID = function (a) {
        do a += ~~(1e6 * Math.random()); while (document.getElementById(a));
        return a
    }, b.prototype.tip = function () {
        if (!this.$tip && (this.$tip = a(this.options.template), 1 != this.$tip.length)) throw new Error(this.type + " `template` option must consist of exactly 1 top-level element!");
        return this.$tip
    }, b.prototype.arrow = function () {
        return this.$arrow = this.$arrow || this.tip().find(".tooltip-arrow")
    }, b.prototype.enable = function () {
        this.enabled = !0
    }, b.prototype.disable = function () {
        this.enabled = !1
    }, b.prototype.toggleEnabled = function () {
        this.enabled = !this.enabled
    }, b.prototype.toggle = function (b) {
        var c = this;
        b && (c = a(b.currentTarget).data("bs." + this.type), c || (c = new this.constructor(b.currentTarget, this.getDelegateOptions()), a(b.currentTarget).data("bs." + this.type, c))), b ? (c.inState.click = !c.inState.click, c.isInStateTrue() ? c.enter(c) : c.leave(c)) : c.tip().hasClass("in") ? c.leave(c) : c.enter(c)
    }, b.prototype.destroy = function () {
        var a = this;
        clearTimeout(this.timeout), this.hide(function () {
            a.$element.off("." + a.type).removeData("bs." + a.type), a.$tip && a.$tip.detach(), a.$tip = null, a.$arrow = null, a.$viewport = null
        })
    };
    var d = a.fn.tooltip;
    a.fn.tooltip = c, a.fn.tooltip.Constructor = b, a.fn.tooltip.noConflict = function () {
        return a.fn.tooltip = d, this
    }
}(jQuery);
var uniqueId = function (a) {
    return (a || "ui-id") + "-" + Math.floor(1e3 * Math.random() + 1)
},
    removeMultiValAttributes = function (a, b, c) {
        var d = (a.attr(b) || "").split(/\s+/),
            e = $.inArray(c, d);
        e !== -1 && d.splice(e, 1), d = $.trim(d.join(" ")), d ? a.attr(b, d) : a.removeAttr(b)
    },
    $colltabs = $('[data-toggle="collapse"]');
$colltabs.attr({
    role: "tab",
    "aria-selected": "false",
    "aria-expanded": "false"
}), $colltabs.each(function (a) {
    var b = $(this),
        c = b.attr("data-target") ? $(b.attr("data-target")) : $(b.attr("href")),
        d = b.attr("data-parent"),
        e = d && $(d),
        f = b.attr("id") || uniqueId("ui-collapse");
    $(e).find("div:not(.collapse,.panel-body), h4").attr("role", "presentation"), b.attr("id", f), e && (e.attr({
        role: "tablist",
        "aria-multiselectable": "true"
    }), c.hasClass("in") ? (b.attr({
        "aria-controls": b.attr("href").substr(1),
        "aria-selected": "true",
        "aria-expanded": "true",
        tabindex: "0"
    }), c.attr({
        role: "tabpanel",
        tabindex: "0",
        "aria-labelledby": f,
        "aria-hidden": "false"
    })) : (b.attr({
        "aria-controls": b.attr("href").substr(1),
        tabindex: "-1"
    }), c.attr({
        role: "tabpanel",
        tabindex: "-1",
        "aria-labelledby": f,
        "aria-hidden": "true"
    })))
});
var collToggle = $.fn.collapse.Constructor.prototype.toggle;
$.fn.collapse.Constructor.prototype.toggle = function () {
    var b, a = this.$parent && this.$parent.find('[aria-expanded="true"]');
    if (a) {
        var g, c = a.attr("data-target") || (b = a.attr("href")) && b.replace(/.*(?=#[^\s]+$)/, ""),
            d = $(c),
            e = this.$element;
        this.$parent;
        this.$parent && (g = this.$parent.find('[data-toggle=collapse][href="#' + this.$element.attr("id") + '"]')), collToggle.apply(this, arguments), $.support.transition && this.$element.one($.support.transition.end, function () {
            a.attr({
                "aria-selected": "false",
                "aria-expanded": "false",
                tabIndex: "-1"
            }), d.attr({
                "aria-hidden": "true",
                tabIndex: "-1"
            }), g.attr({
                "aria-selected": "true",
                "aria-expanded": "true",
                tabIndex: "0"
            }), e.hasClass("in") ? e.attr({
                "aria-hidden": "false",
                tabIndex: "0"
            }) : (g.attr({
                "aria-selected": "false",
                "aria-expanded": "false"
            }), e.attr({
                "aria-hidden": "true",
                tabIndex: "-1"
            }))
        })
    } else collToggle.apply(this, arguments)
}, $.fn.collapse.Constructor.prototype.keydown = function (a) {
    var c, e, b = $(this),
        d = b.closest("div[role=tablist] "),
        f = a.which || a.keyCode;
    b = $(this), /(32|37|38|39|40)/.test(f) && (32 == f && b.click(), c = d.find("[role=tab]"), e = c.index(c.filter(":focus")), 38 != f && 37 != f || e-- , 39 != f && 40 != f || e++ , e < 0 && (e = c.length - 1), e == c.length && (e = 0), c.eq(e).focus(), a.preventDefault(), a.stopPropagation())
}, $(document).on("keydown.collapse.data-api", '[data-toggle="collapse"]', $.fn.collapse.Constructor.prototype.keydown);
var toggle = "[data-toggle=dropdown]",
    $par, firstItem, focusDelay = 200,
    menus = $(toggle).parent().find("ul").attr("role", "menu"),
    lis = menus.find("li").attr("role", "presentation");
lis.find("a").attr({
    role: "menuitem",
    tabIndex: "-1"
}), $(toggle).attr({
    "aria-haspopup": "true",
    "aria-expanded": "false"
}), $(toggle).parent().on("shown.bs.dropdown", function (a) {
    $par = $(this);
    var b = $par.find(toggle);
    b.attr("aria-expanded", "true"), setTimeout(function () {
        firstItem = $(".dropdown-menu [role=menuitem]:visible", $par)[0];
        try {
            firstItem.focus()
        } catch (a) { }
    }, focusDelay)
}), $(toggle).parent().on("hidden.bs.dropdown", function (a) {
    $par = $(this);
    var b = $par.find(toggle);
    b.attr("aria-expanded", "false")
}), $.fn.dropdown.Constructor.prototype.keydown = function (a) {
    var b;
    /(32)/.test(a.keyCode) && (b = $(this).parent(), $(this).trigger("click"), a.preventDefault() && a.stopPropagation())
}, $(document).on("focusout.dropdown.data-api", ".dropdown-menu", function (a) {
    var b = $(this),
        c = this;
    setTimeout(function () {
        $.contains(c, document.activeElement) || (b.parent().removeClass("open"), b.parent().find("[data-toggle=dropdown]").attr("aria-expanded", "false"))
    }, 150)
}).on("keydown.bs.dropdown.data-api", toggle + ", [role=menu]", $.fn.dropdown.Constructor.prototype.keydown);
var $tablist = $(".nav-tabs, .nav-pills"),
    $lis = $tablist.children("li"),
    $tabs = $tablist.find('[data-toggle="tab"], [data-toggle="pill"]');
$tablist.attr("role", "tablist"), $lis.attr("role", "presentation"), $tabs.attr("role", "tab"), $tabs.each(function (a) {
    var b = $($(this).attr("href")),
        c = $(this),
        d = c.attr("id") || uniqueId("ui-tab");
    c.attr("id", d), c.parent().hasClass("active") ? (c.attr({
        tabIndex: "0",
        "aria-selected": "true",
        "aria-controls": c.attr("href").substr(1)
    }), b.attr({
        role: "tabpanel",
        tabIndex: "0",
        "aria-hidden": "false",
        "aria-labelledby": d
    })) : (c.attr({
        tabIndex: "-1",
        "aria-selected": "false",
        "aria-controls": c.attr("href").substr(1)
    }), b.attr({
        role: "tabpanel",
        tabIndex: "-1",
        "aria-hidden": "true",
        "aria-labelledby": d
    }))
}), $.fn.tab.Constructor.prototype.keydown = function (a) {
    var c, e, b = $(this),
        d = b.closest("ul[role=tablist] "),
        f = a.which || a.keyCode;
    if (b = $(this), /(37|38|39|40)/.test(f)) {
        c = d.find("[role=tab]:visible"), e = c.index(c.filter(":focus")), 38 != f && 37 != f || e-- , 39 != f && 40 != f || e++ , e < 0 && (e = c.length - 1), e == c.length && (e = 0);
        var g = c.eq(e);
        "tab" === g.attr("role") && g.tab("show").focus(), a.preventDefault(), a.stopPropagation()
    }
}, $(document).on("keydown.tab.data-api", '[data-toggle="tab"], [data-toggle="pill"]', $.fn.tab.Constructor.prototype.keydown);
var tabactivate = $.fn.tab.Constructor.prototype.activate;
$.fn.tab.Constructor.prototype.activate = function (a, b, c) {
    var d = b.find("> .active");
    d.find("[data-toggle=tab], [data-toggle=pill]").attr({
        tabIndex: "-1",
        "aria-selected": !1
    }), d.filter(".tab-pane").attr({
        "aria-hidden": !0,
        tabIndex: "-1"
    }), tabactivate.apply(this, arguments), a.addClass("active"), a.find("[data-toggle=tab], [data-toggle=pill]").attr({
        tabIndex: "0",
        "aria-selected": !0
    }), a.filter(".tab-pane").attr({
        "aria-hidden": !1,
        tabIndex: "0"
    })
};
var fakewaffle = function (a, b) {
    "use strict";
    var c = 0;
    return b.responsiveTabs = function (d) {
        b.currentPosition = "tabs";
        var e = a(".nav-tabs.responsive, .nav-pills.responsive"),
            f = "",
            g = "",
            h = "";
        void 0 === d && (d = ["xs", "sm"]), a.each(d, function () {
            f += " hidden-" + this, g += " visible-" + this
        }), a.each(e, function () {
            var b = a(this),
                d = b.find('[data-toggle="tab"]'),
                e = a("<div></div>", {
                    class: "panel-group responsive" + g,
                    id: "collapse-NaN" + c++
                });
            a.each(d, function () {
                var c = a(this),
                    d = void 0 === c.attr("class") ? "" : c.attr("class"),
                    f = "accordion-toggle collapsed",
                    g = void 0 === c.parent().attr("class") ? "" : c.parent().attr("class"),
                    i = "panel panel-default",
                    j = c.get(0).hash.replace("#", "collapse-");
                d.length > 0 && (f += " " + d), g.length > 0 && (g = g.replace(/\bactive\b/g, ""), i += " " + g, i = i.replace(/\s{2,}/g, " "), i = i.replace(/^\s+|\s+$/g, "")), c.parent().hasClass("active") && (h = "#" + j), e.append(a("<div>").attr("class", i).html(a("<div>").attr("class", "panel-heading").html(a("<h4>").attr("class", "panel-title").html(a("<a>", {
                    class: f,
                    "data-toggle": "collapse",
                    "data-parent": "#collapse-" + b.attr("id"),
                    href: "#" + j,
                    html: c.html()
                })))).append(a("<div>", {
                    id: j,
                    class: "panel-collapse collapse"
                })))
            }), b.next().after(e), b.addClass(f), a(".tab-content.responsive").addClass(f)
        }), b.checkResize(), b.bindTabToCollapse(), h && a(h).collapse("show")
    }, b.checkResize = function () {
        a(".panel-group.responsive").is(":visible") === !0 && "tabs" === b.currentPosition ? (b.tabToPanel(), b.currentPosition = "panel") : a(".panel-group.responsive").is(":visible") === !1 && "panel" === b.currentPosition && (b.panelToTab(), b.currentPosition = "tabs")
    }, b.tabToPanel = function () {
        var b = a(".nav-tabs.responsive, .nav-pills.responsive");
        a.each(b, function (b, c) {
            var d = a(c).next(".tab-content").find(".tab-pane");
            a.each(d, function (b, c) {
                var d = a(c).attr("id").replace(/^/, "#collapse-");
                a(c).removeClass("tab-pane").addClass("panel-body").appendTo(a(d))
            })
        })
    }, b.panelToTab = function () {
        var b = a(".panel-group.responsive");
        a.each(b, function (b, c) {
            var d = a(c).attr("id").replace("collapse-", "#"),
                e = a(d).next(".tab-content")[0],
                f = a(c).find(".panel-body");
            f.removeClass("panel-body").addClass("tab-pane").appendTo(a(e))
        })
    }, b.bindTabToCollapse = function () {
        var b = a(".nav-tabs.responsive, .nav-pills.responsive").find("li a"),
            c = a(".panel-group.responsive").find(".panel-collapse");
        b.on("shown.bs.tab", function (b) {
            var c = a(b.currentTarget.hash.replace(/#/, "#collapse-"));
            if (c.collapse("show"), b.relatedTarget) {
                var d = a(b.relatedTarget.hash.replace(/#/, "#collapse-"));
                d.collapse("hide")
            }
        }), c.on("shown.bs.collapse", function (b) {
            var c = a(b.target).context.id.replace(/collapse-/g, "#");
            a('a[href="' + c + '"]').tab("show");
            var d = a(b.currentTarget).closest(".panel-group.responsive");
            a(d).find(".panel-body").removeClass("active"), a(b.currentTarget).find(".panel-body").addClass("active")
        })
    }, a(window).resize(function () {
        b.checkResize()
    }), b
}(window.jQuery, fakewaffle || {});
! function (a, b, c, d) {
    function e(b, c) {
        this.settings = null, this.options = a.extend({}, e.Defaults, c), this.$element = a(b), this._handlers = {}, this._plugins = {}, this._supress = {}, this._current = null, this._speed = null, this._coordinates = [], this._breakpoint = null, this._width = null, this._items = [], this._clones = [], this._mergers = [], this._widths = [], this._invalidated = {}, this._pipe = [], this._drag = {
            time: null,
            target: null,
            pointer: null,
            stage: {
                start: null,
                current: null
            },
            direction: null
        }, this._states = {
            current: {},
            tags: {
                initializing: ["busy"],
                animating: ["busy"],
                dragging: ["interacting"]
            }
        }, a.each(["onResize", "onThrottledResize"], a.proxy(function (b, c) {
            this._handlers[c] = a.proxy(this[c], this)
        }, this)), a.each(e.Plugins, a.proxy(function (a, b) {
            this._plugins[a.charAt(0).toLowerCase() + a.slice(1)] = new b(this)
        }, this)), a.each(e.Workers, a.proxy(function (b, c) {
            this._pipe.push({
                filter: c.filter,
                run: a.proxy(c.run, this)
            })
        }, this)), this.setup(), this.initialize()
    }
    e.Defaults = {
        items: 3,
        loop: !1,
        center: !1,
        rewind: !1,
        mouseDrag: !0,
        touchDrag: !0,
        pullDrag: !0,
        freeDrag: !1,
        margin: 0,
        stagePadding: 0,
        merge: !1,
        mergeFit: !0,
        autoWidth: !1,
        startPosition: 0,
        rtl: !1,
        smartSpeed: 250,
        fluidSpeed: !1,
        dragEndSpeed: !1,
        responsive: {},
        responsiveRefreshRate: 200,
        responsiveBaseElement: b,
        fallbackEasing: "swing",
        info: !1,
        nestedItemSelector: !1,
        itemElement: "div",
        stageElement: "div",
        refreshClass: "owl-refresh",
        loadedClass: "owl-loaded",
        loadingClass: "owl-loading",
        rtlClass: "owl-rtl",
        responsiveClass: "owl-responsive",
        dragClass: "owl-drag",
        itemClass: "owl-item",
        stageClass: "owl-stage",
        stageOuterClass: "owl-stage-outer",
        grabClass: "owl-grab"
    }, e.Width = {
        Default: "default",
        Inner: "inner",
        Outer: "outer"
    }, e.Type = {
        Event: "event",
        State: "state"
    }, e.Plugins = {}, e.Workers = [{
        filter: ["width", "settings"],
        run: function () {
            this._width = this.$element.width()
        }
    }, {
        filter: ["width", "items", "settings"],
        run: function (a) {
            a.current = this._items && this._items[this.relative(this._current)]
        }
    }, {
        filter: ["items", "settings"],
        run: function () {
            this.$stage.children(".cloned").remove()
        }
    }, {
        filter: ["width", "items", "settings"],
        run: function (a) {
            var b = this.settings.margin || "",
                c = !this.settings.autoWidth,
                d = this.settings.rtl,
                e = {
                    width: "auto",
                    "margin-left": d ? b : "",
                    "margin-right": d ? "" : b
                };
            !c && this.$stage.children().css(e), a.css = e
        }
    }, {
        filter: ["width", "items", "settings"],
        run: function (a) {
            var b = (this.width() / this.settings.items).toFixed(3) - this.settings.margin,
                c = null,
                d = this._items.length,
                e = !this.settings.autoWidth,
                f = [];
            for (a.items = {
                merge: !1,
                width: b
            }; d--;) c = this._mergers[d], c = this.settings.mergeFit && Math.min(c, this.settings.items) || c, a.items.merge = c > 1 || a.items.merge, f[d] = e ? b * c : this._items[d].width();
            this._widths = f
        }
    }, {
        filter: ["items", "settings"],
        run: function () {
            var b = [],
                c = this._items,
                d = this.settings,
                e = Math.max(2 * d.items, 4),
                f = 2 * Math.ceil(c.length / 2),
                g = d.loop && c.length ? d.rewind ? e : Math.max(e, f) : 0,
                h = "",
                i = "";
            for (g /= 2; g--;) b.push(this.normalize(b.length / 2, !0)), h += c[b[b.length - 1]][0].outerHTML, b.push(this.normalize(c.length - 1 - (b.length - 1) / 2, !0)), i = c[b[b.length - 1]][0].outerHTML + i;
            this._clones = b, a(h).addClass("cloned").appendTo(this.$stage), a(i).addClass("cloned").prependTo(this.$stage)
        }
    }, {
        filter: ["width", "items", "settings"],
        run: function () {
            for (var a = this.settings.rtl ? 1 : -1, b = this._clones.length + this._items.length, c = -1, d = 0, e = 0, f = []; ++c < b;) d = f[c - 1] || 0, e = this._widths[this.relative(c)] + this.settings.margin, f.push(d + e * a);
            this._coordinates = f
        }
    }, {
        filter: ["width", "items", "settings"],
        run: function () {
            var a = this.settings.stagePadding,
                b = this._coordinates,
                c = {
                    width: Math.ceil(Math.abs(b[b.length - 1])) + 2 * a,
                    "padding-left": a || "",
                    "padding-right": a || ""
                };
            this.$stage.css(c)
        }
    }, {
        filter: ["width", "items", "settings"],
        run: function (a) {
            var b = this._coordinates.length,
                c = !this.settings.autoWidth,
                d = this.$stage.children();
            if (c && a.items.merge)
                for (; b--;) a.css.width = this._widths[this.relative(b)], d.eq(b).css(a.css);
            else c && (a.css.width = a.items.width, d.css(a.css))
        }
    }, {
        filter: ["items"],
        run: function () {
            this._coordinates.length < 1 && this.$stage.removeAttr("style")
        }
    }, {
        filter: ["width", "items", "settings"],
        run: function (a) {
            a.current = a.current ? this.$stage.children().index(a.current) : 0, a.current = Math.max(this.minimum(), Math.min(this.maximum(), a.current)), this.reset(a.current)
        }
    }, {
        filter: ["position"],
        run: function () {
            this.animate(this.coordinates(this._current))
        }
    }, {
        filter: ["width", "position", "items", "settings"],
        run: function () {
            var e, f, h, i, a = this.settings.rtl ? 1 : -1,
                b = 2 * this.settings.stagePadding,
                c = this.coordinates(this.current()) + b,
                d = c + this.width() * a,
                g = [];
            for (h = 0, i = this._coordinates.length; h < i; h++) e = this._coordinates[h - 1] || 0, f = Math.abs(this._coordinates[h]) + b * a, (this.op(e, "<=", c) && this.op(e, ">", d) || this.op(f, "<", c) && this.op(f, ">", d)) && g.push(h);
            this.$stage.children(".active").removeClass("active"), this.$stage.children(":eq(" + g.join("), :eq(") + ")").addClass("active"), this.settings.center && (this.$stage.children(".center").removeClass("center"), this.$stage.children().eq(this.current()).addClass("center"))
        }
    }], e.prototype.initialize = function () {
        if (this.enter("initializing"), this.trigger("initialize"), this.$element.toggleClass(this.settings.rtlClass, this.settings.rtl), this.settings.autoWidth && !this.is("pre-loading")) {
            var b, c, e;
            b = this.$element.find("img"), c = this.settings.nestedItemSelector ? "." + this.settings.nestedItemSelector : d, e = this.$element.children(c).width(), b.length && e <= 0 && this.preloadAutoWidthImages(b)
        }
        this.$element.addClass(this.options.loadingClass), this.$stage = a("<" + this.settings.stageElement + ' class="' + this.settings.stageClass + '"/>').wrap('<div class="' + this.settings.stageOuterClass + '"/>'), this.$element.append(this.$stage.parent()), this.replace(this.$element.children().not(this.$stage.parent())), this.$element.is(":visible") ? this.refresh() : this.invalidate("width"), this.$element.removeClass(this.options.loadingClass).addClass(this.options.loadedClass), this.registerEventHandlers(), this.leave("initializing"), this.trigger("initialized")
    }, e.prototype.setup = function () {
        var b = this.viewport(),
            c = this.options.responsive,
            d = -1,
            e = null;
        c ? (a.each(c, function (a) {
            a <= b && a > d && (d = Number(a))
        }), e = a.extend({}, this.options, c[d]), delete e.responsive, e.responsiveClass && this.$element.attr("class", this.$element.attr("class").replace(new RegExp("(" + this.options.responsiveClass + "-)\\S+\\s", "g"), "$1" + d))) : e = a.extend({}, this.options), null !== this.settings && this._breakpoint === d || (this.trigger("change", {
            property: {
                name: "settings",
                value: e
            }
        }), this._breakpoint = d, this.settings = e, this.invalidate("settings"), this.trigger("changed", {
            property: {
                name: "settings",
                value: this.settings
            }
        }))
    }, e.prototype.optionsLogic = function () {
        this.settings.autoWidth && (this.settings.stagePadding = !1, this.settings.merge = !1)
    }, e.prototype.prepare = function (b) {
        var c = this.trigger("prepare", {
            content: b
        });
        return c.data || (c.data = a("<" + this.settings.itemElement + "/>").addClass(this.options.itemClass).append(b)), this.trigger("prepared", {
            content: c.data
        }), c.data
    }, e.prototype.update = function () {
        for (var b = 0, c = this._pipe.length, d = a.proxy(function (a) {
            return this[a]
        }, this._invalidated), e = {}; b < c;)(this._invalidated.all || a.grep(this._pipe[b].filter, d).length > 0) && this._pipe[b].run(e), b++;
        this._invalidated = {}, !this.is("valid") && this.enter("valid")
    }, e.prototype.width = function (a) {
        switch (a = a || e.Width.Default) {
            case e.Width.Inner:
            case e.Width.Outer:
                return this._width;
            default:
                return this._width - 2 * this.settings.stagePadding + this.settings.margin
        }
    }, e.prototype.refresh = function () {
        this.enter("refreshing"), this.trigger("refresh"), this.setup(), this.optionsLogic(), this.$element.addClass(this.options.refreshClass), this.update(), this.$element.removeClass(this.options.refreshClass), this.leave("refreshing"), this.trigger("refreshed")
    }, e.prototype.onThrottledResize = function () {
        b.clearTimeout(this.resizeTimer), this.resizeTimer = b.setTimeout(this._handlers.onResize, this.settings.responsiveRefreshRate)
    }, e.prototype.onResize = function () {
        return !!this._items.length && (this._width !== this.$element.width() && (!!this.$element.is(":visible") && (this.enter("resizing"), this.trigger("resize").isDefaultPrevented() ? (this.leave("resizing"), !1) : (this.invalidate("width"), this.refresh(), this.leave("resizing"), void this.trigger("resized")))))
    }, e.prototype.registerEventHandlers = function () {
        a.support.transition && this.$stage.on(a.support.transition.end + ".owl.core", a.proxy(this.onTransitionEnd, this)), this.settings.responsive !== !1 && this.on(b, "resize", this._handlers.onThrottledResize), this.settings.mouseDrag && (this.$element.addClass(this.options.dragClass), this.$stage.on("mousedown.owl.core", a.proxy(this.onDragStart, this)), this.$stage.on("dragstart.owl.core selectstart.owl.core", function () {
            return !1
        })), this.settings.touchDrag && (this.$stage.on("touchstart.owl.core", a.proxy(this.onDragStart, this)), this.$stage.on("touchcancel.owl.core", a.proxy(this.onDragEnd, this)))
    }, e.prototype.onDragStart = function (b) {
        var d = null;
        3 !== b.which && (a.support.transform ? (d = this.$stage.css("transform").replace(/.*\(|\)| /g, "").split(","), d = {
            x: d[16 === d.length ? 12 : 4],
            y: d[16 === d.length ? 13 : 5]
        }) : (d = this.$stage.position(), d = {
            x: this.settings.rtl ? d.left + this.$stage.width() - this.width() + this.settings.margin : d.left,
            y: d.top
        }), this.is("animating") && (a.support.transform ? this.animate(d.x) : this.$stage.stop(), this.invalidate("position")), this.$element.toggleClass(this.options.grabClass, "mousedown" === b.type), this.speed(0), this._drag.time = (new Date).getTime(), this._drag.target = a(b.target), this._drag.stage.start = d, this._drag.stage.current = d, this._drag.pointer = this.pointer(b), a(c).on("mouseup.owl.core touchend.owl.core", a.proxy(this.onDragEnd, this)), a(c).one("mousemove.owl.core touchmove.owl.core", a.proxy(function (b) {
            var d = this.difference(this._drag.pointer, this.pointer(b));
            a(c).on("mousemove.owl.core touchmove.owl.core", a.proxy(this.onDragMove, this)), Math.abs(d.x) < Math.abs(d.y) && this.is("valid") || (b.preventDefault(), this.enter("dragging"), this.trigger("drag"))
        }, this)))
    }, e.prototype.onDragMove = function (a) {
        var b = null,
            c = null,
            d = null,
            e = this.difference(this._drag.pointer, this.pointer(a)),
            f = this.difference(this._drag.stage.start, e);
        this.is("dragging") && (a.preventDefault(), this.settings.loop ? (b = this.coordinates(this.minimum()), c = this.coordinates(this.maximum() + 1) - b, f.x = ((f.x - b) % c + c) % c + b) : (b = this.settings.rtl ? this.coordinates(this.maximum()) : this.coordinates(this.minimum()), c = this.settings.rtl ? this.coordinates(this.minimum()) : this.coordinates(this.maximum()), d = this.settings.pullDrag ? -1 * e.x / 5 : 0, f.x = Math.max(Math.min(f.x, b + d), c + d)), this._drag.stage.current = f, this.animate(f.x))
    }, e.prototype.onDragEnd = function (b) {
        var d = this.difference(this._drag.pointer, this.pointer(b)),
            e = this._drag.stage.current,
            f = d.x > 0 ^ this.settings.rtl ? "left" : "right";
        a(c).off(".owl.core"), this.$element.removeClass(this.options.grabClass), (0 !== d.x && this.is("dragging") || !this.is("valid")) && (this.speed(this.settings.dragEndSpeed || this.settings.smartSpeed), this.current(this.closest(e.x, 0 !== d.x ? f : this._drag.direction)), this.invalidate("position"), this.update(), this._drag.direction = f, (Math.abs(d.x) > 3 || (new Date).getTime() - this._drag.time > 300) && this._drag.target.one("click.owl.core", function () {
            return !1
        })), this.is("dragging") && (this.leave("dragging"), this.trigger("dragged"))
    }, e.prototype.closest = function (b, c) {
        var d = -1,
            e = 30,
            f = this.width(),
            g = this.coordinates();
        return this.settings.freeDrag || a.each(g, a.proxy(function (a, h) {
            return b > h - e && b < h + e ? d = a : this.op(b, "<", h) && this.op(b, ">", g[a + 1] || h - f) && (d = "left" === c ? a + 1 : a), d === -1
        }, this)), this.settings.loop || (this.op(b, ">", g[this.minimum()]) ? d = b = this.minimum() : this.op(b, "<", g[this.maximum()]) && (d = b = this.maximum())), d
    }, e.prototype.animate = function (b) {
        var c = this.speed() > 0;
        this.is("animating") && this.onTransitionEnd(), c && (this.enter("animating"), this.trigger("translate")), a.support.transform3d && a.support.transition ? this.$stage.css({
            transform: "translate3d(" + b + "px,0px,0px)",
            transition: this.speed() / 1e3 + "s"
        }) : c ? this.$stage.animate({
            left: b + "px"
        }, this.speed(), this.settings.fallbackEasing, a.proxy(this.onTransitionEnd, this)) : this.$stage.css({
            left: b + "px"
        })
    }, e.prototype.is = function (a) {
        return this._states.current[a] && this._states.current[a] > 0
    }, e.prototype.current = function (a) {
        if (a === d) return this._current;
        if (0 === this._items.length) return d;
        if (a = this.normalize(a), this._current !== a) {
            var b = this.trigger("change", {
                property: {
                    name: "position",
                    value: a
                }
            });
            b.data !== d && (a = this.normalize(b.data)), this._current = a, this.invalidate("position"), this.trigger("changed", {
                property: {
                    name: "position",
                    value: this._current
                }
            })
        }
        return this._current
    }, e.prototype.invalidate = function (b) {
        return "string" === a.type(b) && (this._invalidated[b] = !0, this.is("valid") && this.leave("valid")), a.map(this._invalidated, function (a, b) {
            return b
        })
    }, e.prototype.reset = function (a) {
        a = this.normalize(a), a !== d && (this._speed = 0, this._current = a, this.suppress(["translate", "translated"]), this.animate(this.coordinates(a)), this.release(["translate", "translated"]))
    }, e.prototype.normalize = function (b, c) {
        var e = this._items.length,
            f = c ? 0 : this._clones.length;
        return !a.isNumeric(b) || e < 1 ? b = d : (b < 0 || b >= e + f) && (b = ((b - f / 2) % e + e) % e + f / 2), b
    }, e.prototype.relative = function (a) {
        return a -= this._clones.length / 2, this.normalize(a, !0)
    }, e.prototype.maximum = function (a) {
        var f, b = this.settings,
            c = this._coordinates.length,
            d = Math.abs(this._coordinates[c - 1]) - this._width,
            e = -1;
        if (b.loop) c = this._clones.length / 2 + this._items.length - 1;
        else if (b.autoWidth || b.merge)
            for (; c - e > 1;) Math.abs(this._coordinates[f = c + e >> 1]) < d ? e = f : c = f;
        else c = b.center ? this._items.length - 1 : this._items.length - b.items;
        return a && (c -= this._clones.length / 2), Math.max(c, 0)
    }, e.prototype.minimum = function (a) {
        return a ? 0 : this._clones.length / 2
    }, e.prototype.items = function (a) {
        return a === d ? this._items.slice() : (a = this.normalize(a, !0), this._items[a])
    }, e.prototype.mergers = function (a) {
        return a === d ? this._mergers.slice() : (a = this.normalize(a, !0), this._mergers[a])
    }, e.prototype.clones = function (b) {
        var c = this._clones.length / 2,
            e = c + this._items.length,
            f = function (a) {
                return a % 2 === 0 ? e + a / 2 : c - (a + 1) / 2
            };
        return b === d ? a.map(this._clones, function (a, b) {
            return f(b)
        }) : a.map(this._clones, function (a, c) {
            return a === b ? f(c) : null
        })
    }, e.prototype.speed = function (a) {
        return a !== d && (this._speed = a), this._speed
    }, e.prototype.coordinates = function (b) {
        var c = null;
        return b === d ? a.map(this._coordinates, a.proxy(function (a, b) {
            return this.coordinates(b)
        }, this)) : (this.settings.center ? (c = this._coordinates[b], c += (this.width() - c + (this._coordinates[b - 1] || 0)) / 2 * (this.settings.rtl ? -1 : 1)) : c = this._coordinates[b - 1] || 0, c)
    }, e.prototype.duration = function (a, b, c) {
        return Math.min(Math.max(Math.abs(b - a), 1), 6) * Math.abs(c || this.settings.smartSpeed)
    }, e.prototype.to = function (a, b) {
        var c = this.current(),
            d = null,
            e = a - this.relative(c),
            f = (e > 0) - (e < 0),
            g = this._items.length,
            h = this.minimum(),
            i = this.maximum();
        this.settings.loop ? (!this.settings.rewind && Math.abs(e) > g / 2 && (e += f * -1 * g), a = c + e, d = ((a - h) % g + g) % g + h, d !== a && d - e <= i && d - e > 0 && (c = d - e, a = d, this.reset(c))) : this.settings.rewind ? (i += 1, a = (a % i + i) % i) : a = Math.max(h, Math.min(i, a)), this.speed(this.duration(c, a, b)), this.current(a), this.$element.is(":visible") && this.update()
    }, e.prototype.next = function (a) {
        a = a || !1, this.to(this.relative(this.current()) + 1, a)
    }, e.prototype.prev = function (a) {
        a = a || !1, this.to(this.relative(this.current()) - 1, a)
    }, e.prototype.onTransitionEnd = function (a) {
        return (a === d || (a.stopPropagation(), (a.target || a.srcElement || a.originalTarget) === this.$stage.get(0))) && (this.leave("animating"), void this.trigger("translated"))
    }, e.prototype.viewport = function () {
        var d;
        if (this.options.responsiveBaseElement !== b) d = a(this.options.responsiveBaseElement).width();
        else if (b.innerWidth) d = b.innerWidth;
        else {
            if (!c.documentElement || !c.documentElement.clientWidth) throw "Can not detect viewport width.";
            d = c.documentElement.clientWidth
        }
        return d
    }, e.prototype.replace = function (b) {
        this.$stage.empty(), this._items = [], b && (b = b instanceof jQuery ? b : a(b)), this.settings.nestedItemSelector && (b = b.find("." + this.settings.nestedItemSelector)), b.filter(function () {
            return 1 === this.nodeType
        }).each(a.proxy(function (a, b) {
            b = this.prepare(b), this.$stage.append(b), this._items.push(b), this._mergers.push(1 * b.find("[data-merge]").andSelf("[data-merge]").attr("data-merge") || 1)
        }, this)), this.reset(a.isNumeric(this.settings.startPosition) ? this.settings.startPosition : 0), this.invalidate("items")
    }, e.prototype.add = function (b, c) {
        var e = this.relative(this._current);
        c = c === d ? this._items.length : this.normalize(c, !0), b = b instanceof jQuery ? b : a(b), this.trigger("add", {
            content: b,
            position: c
        }), b = this.prepare(b), 0 === this._items.length || c === this._items.length ? (0 === this._items.length && this.$stage.append(b), 0 !== this._items.length && this._items[c - 1].after(b), this._items.push(b), this._mergers.push(1 * b.find("[data-merge]").andSelf("[data-merge]").attr("data-merge") || 1)) : (this._items[c].before(b), this._items.splice(c, 0, b), this._mergers.splice(c, 0, 1 * b.find("[data-merge]").andSelf("[data-merge]").attr("data-merge") || 1)),
            this._items[e] && this.reset(this._items[e].index()), this.invalidate("items"), this.trigger("added", {
                content: b,
                position: c
            })
    }, e.prototype.remove = function (a) {
        a = this.normalize(a, !0), a !== d && (this.trigger("remove", {
            content: this._items[a],
            position: a
        }), this._items[a].remove(), this._items.splice(a, 1), this._mergers.splice(a, 1), this.invalidate("items"), this.trigger("removed", {
            content: null,
            position: a
        }))
    }, e.prototype.preloadAutoWidthImages = function (b) {
        b.each(a.proxy(function (b, c) {
            this.enter("pre-loading"), c = a(c), a(new Image).one("load", a.proxy(function (a) {
                c.attr("src", a.target.src), c.css("opacity", 1), this.leave("pre-loading"), !this.is("pre-loading") && !this.is("initializing") && this.refresh()
            }, this)).attr("src", c.attr("src") || c.attr("data-src") || c.attr("data-src-retina"))
        }, this))
    }, e.prototype.destroy = function () {
        this.$element.off(".owl.core"), this.$stage.off(".owl.core"), a(c).off(".owl.core"), this.settings.responsive !== !1 && (b.clearTimeout(this.resizeTimer), this.off(b, "resize", this._handlers.onThrottledResize));
        for (var d in this._plugins) this._plugins[d].destroy();
        this.$stage.children(".cloned").remove(), this.$stage.unwrap(), this.$stage.children().contents().unwrap(), this.$stage.children().unwrap(), this.$element.removeClass(this.options.refreshClass).removeClass(this.options.loadingClass).removeClass(this.options.loadedClass).removeClass(this.options.rtlClass).removeClass(this.options.dragClass).removeClass(this.options.grabClass).attr("class", this.$element.attr("class").replace(new RegExp(this.options.responsiveClass + "-\\S+\\s", "g"), "")).removeData("owl.carousel")
    }, e.prototype.op = function (a, b, c) {
        var d = this.settings.rtl;
        switch (b) {
            case "<":
                return d ? a > c : a < c;
            case ">":
                return d ? a < c : a > c;
            case ">=":
                return d ? a <= c : a >= c;
            case "<=":
                return d ? a >= c : a <= c
        }
    }, e.prototype.on = function (a, b, c, d) {
        a.addEventListener ? a.addEventListener(b, c, d) : a.attachEvent && a.attachEvent("on" + b, c)
    }, e.prototype.off = function (a, b, c, d) {
        a.removeEventListener ? a.removeEventListener(b, c, d) : a.detachEvent && a.detachEvent("on" + b, c)
    }, e.prototype.trigger = function (b, c, d, f, g) {
        var h = {
            item: {
                count: this._items.length,
                index: this.current()
            }
        },
            i = a.camelCase(a.grep(["on", b, d], function (a) {
                return a
            }).join("-").toLowerCase()),
            j = a.Event([b, "owl", d || "carousel"].join(".").toLowerCase(), a.extend({
                relatedTarget: this
            }, h, c));
        return this._supress[b] || (a.each(this._plugins, function (a, b) {
            b.onTrigger && b.onTrigger(j)
        }), this.register({
            type: e.Type.Event,
            name: b
        }), this.$element.trigger(j), this.settings && "function" == typeof this.settings[i] && this.settings[i].call(this, j)), j
    }, e.prototype.enter = function (b) {
        a.each([b].concat(this._states.tags[b] || []), a.proxy(function (a, b) {
            this._states.current[b] === d && (this._states.current[b] = 0), this._states.current[b]++
        }, this))
    }, e.prototype.leave = function (b) {
        a.each([b].concat(this._states.tags[b] || []), a.proxy(function (a, b) {
            this._states.current[b]--
        }, this))
    }, e.prototype.register = function (b) {
        if (b.type === e.Type.Event) {
            if (a.event.special[b.name] || (a.event.special[b.name] = {}), !a.event.special[b.name].owl) {
                var c = a.event.special[b.name]._default;
                a.event.special[b.name]._default = function (a) {
                    return !c || !c.apply || a.namespace && a.namespace.indexOf("owl") !== -1 ? a.namespace && a.namespace.indexOf("owl") > -1 : c.apply(this, arguments)
                }, a.event.special[b.name].owl = !0
            }
        } else b.type === e.Type.State && (this._states.tags[b.name] ? this._states.tags[b.name] = this._states.tags[b.name].concat(b.tags) : this._states.tags[b.name] = b.tags, this._states.tags[b.name] = a.grep(this._states.tags[b.name], a.proxy(function (c, d) {
            return a.inArray(c, this._states.tags[b.name]) === d
        }, this)))
    }, e.prototype.suppress = function (b) {
        a.each(b, a.proxy(function (a, b) {
            this._supress[b] = !0
        }, this))
    }, e.prototype.release = function (b) {
        a.each(b, a.proxy(function (a, b) {
            delete this._supress[b]
        }, this))
    }, e.prototype.pointer = function (a) {
        var c = {
            x: null,
            y: null
        };
        return a = a.originalEvent || a || b.event, a = a.touches && a.touches.length ? a.touches[0] : a.changedTouches && a.changedTouches.length ? a.changedTouches[0] : a, a.pageX ? (c.x = a.pageX, c.y = a.pageY) : (c.x = a.clientX, c.y = a.clientY), c
    }, e.prototype.difference = function (a, b) {
        return {
            x: a.x - b.x,
            y: a.y - b.y
        }
    }, a.fn.owlCarousel = function (b) {
        var c = Array.prototype.slice.call(arguments, 1);
        return this.each(function () {
            var d = a(this),
                f = d.data("owl.carousel");
            f || (f = new e(this, "object" == typeof b && b), d.data("owl.carousel", f), a.each(["next", "prev", "to", "destroy", "refresh", "replace", "add", "remove"], function (b, c) {
                f.register({
                    type: e.Type.Event,
                    name: c
                }), f.$element.on(c + ".owl.carousel.core", a.proxy(function (a) {
                    a.namespace && a.relatedTarget !== this && (this.suppress([c]), f[c].apply(this, [].slice.call(arguments, 1)), this.release([c]))
                }, f))
            })), "string" == typeof b && "_" !== b.charAt(0) && f[b].apply(f, c)
        })
    }, a.fn.owlCarousel.Constructor = e
}(window.Zepto || window.jQuery, window, document),
    function (a, b, c, d) {
        var e = function (b) {
            this._core = b, this._interval = null, this._visible = null, this._handlers = {
                "initialized.owl.carousel": a.proxy(function (a) {
                    a.namespace && this._core.settings.autoRefresh && this.watch()
                }, this)
            }, this._core.options = a.extend({}, e.Defaults, this._core.options), this._core.$element.on(this._handlers)
        };
        e.Defaults = {
            autoRefresh: !0,
            autoRefreshInterval: 500
        }, e.prototype.watch = function () {
            this._interval || (this._visible = this._core.$element.is(":visible"), this._interval = b.setInterval(a.proxy(this.refresh, this), this._core.settings.autoRefreshInterval))
        }, e.prototype.refresh = function () {
            this._core.$element.is(":visible") !== this._visible && (this._visible = !this._visible, this._core.$element.toggleClass("owl-hidden", !this._visible), this._visible && this._core.invalidate("width") && this._core.refresh())
        }, e.prototype.destroy = function () {
            var a, c;
            b.clearInterval(this._interval);
            for (a in this._handlers) this._core.$element.off(a, this._handlers[a]);
            for (c in Object.getOwnPropertyNames(this)) "function" != typeof this[c] && (this[c] = null)
        }, a.fn.owlCarousel.Constructor.Plugins.AutoRefresh = e
    }(window.Zepto || window.jQuery, window, document),
    function (a, b, c, d) {
        var e = function (b) {
            this._core = b, this._loaded = [], this._handlers = {
                "initialized.owl.carousel change.owl.carousel": a.proxy(function (b) {
                    if (b.namespace && this._core.settings && this._core.settings.lazyLoad && (b.property && "position" == b.property.name || "initialized" == b.type))
                        for (var c = this._core.settings, d = c.center && Math.ceil(c.items / 2) || c.items, e = c.center && d * -1 || 0, f = (b.property && b.property.value || this._core.current()) + e, g = this._core.clones().length, h = a.proxy(function (a, b) {
                            this.load(b)
                        }, this); e++ < d;) this.load(g / 2 + this._core.relative(f)), g && a.each(this._core.clones(this._core.relative(f)), h), f++
                }, this)
            }, this._core.options = a.extend({}, e.Defaults, this._core.options), this._core.$element.on(this._handlers)
        };
        e.Defaults = {
            lazyLoad: !1
        }, e.prototype.load = function (c) {
            var d = this._core.$stage.children().eq(c),
                e = d && d.find(".owl-lazy");
            !e || a.inArray(d.get(0), this._loaded) > -1 || (e.each(a.proxy(function (c, d) {
                var f, e = a(d),
                    g = b.devicePixelRatio > 1 && e.attr("data-src-retina") || e.attr("data-src");
                this._core.trigger("load", {
                    element: e,
                    url: g
                }, "lazy"), e.is("img") ? e.one("load.owl.lazy", a.proxy(function () {
                    e.css("opacity", 1), this._core.trigger("loaded", {
                        element: e,
                        url: g
                    }, "lazy")
                }, this)).attr("src", g) : (f = new Image, f.onload = a.proxy(function () {
                    e.css({
                        "background-image": "url(" + g + ")",
                        opacity: "1"
                    }), this._core.trigger("loaded", {
                        element: e,
                        url: g
                    }, "lazy")
                }, this), f.src = g)
            }, this)), this._loaded.push(d.get(0)))
        }, e.prototype.destroy = function () {
            var a, b;
            for (a in this.handlers) this._core.$element.off(a, this.handlers[a]);
            for (b in Object.getOwnPropertyNames(this)) "function" != typeof this[b] && (this[b] = null)
        }, a.fn.owlCarousel.Constructor.Plugins.Lazy = e
    }(window.Zepto || window.jQuery, window, document),
    function (a, b, c, d) {
        var e = function (b) {
            this._core = b, this._handlers = {
                "initialized.owl.carousel refreshed.owl.carousel": a.proxy(function (a) {
                    a.namespace && this._core.settings.autoHeight && this.update()
                }, this),
                "changed.owl.carousel": a.proxy(function (a) {
                    a.namespace && this._core.settings.autoHeight && "position" == a.property.name && this.update()
                }, this),
                "loaded.owl.lazy": a.proxy(function (a) {
                    a.namespace && this._core.settings.autoHeight && a.element.closest("." + this._core.settings.itemClass).index() === this._core.current() && this.update()
                }, this)
            }, this._core.options = a.extend({}, e.Defaults, this._core.options), this._core.$element.on(this._handlers)
        };
        e.Defaults = {
            autoHeight: !1,
            autoHeightClass: "owl-height"
        }, e.prototype.update = function () {
            var b = this._core._current,
                c = b + this._core.settings.items,
                d = this._core.$stage.children().toArray().slice(b, c);
            heights = [], maxheight = 0, a.each(d, function (b, c) {
                heights.push(a(c).height())
            }), maxheight = Math.max.apply(null, heights), this._core.$stage.parent().height(maxheight).addClass(this._core.settings.autoHeightClass)
        }, e.prototype.destroy = function () {
            var a, b;
            for (a in this._handlers) this._core.$element.off(a, this._handlers[a]);
            for (b in Object.getOwnPropertyNames(this)) "function" != typeof this[b] && (this[b] = null)
        }, a.fn.owlCarousel.Constructor.Plugins.AutoHeight = e
    }(window.Zepto || window.jQuery, window, document),
    function (a, b, c, d) {
        var e = function (b) {
            this._core = b, this._videos = {}, this._playing = null, this._handlers = {
                "initialized.owl.carousel": a.proxy(function (a) {
                    a.namespace && this._core.register({
                        type: "state",
                        name: "playing",
                        tags: ["interacting"]
                    })
                }, this),
                "resize.owl.carousel": a.proxy(function (a) {
                    a.namespace && this._core.settings.video && this.isInFullScreen() && a.preventDefault()
                }, this),
                "refreshed.owl.carousel": a.proxy(function (a) {
                    a.namespace && this._core.is("resizing") && this._core.$stage.find(".cloned .owl-video-frame").remove()
                }, this),
                "changed.owl.carousel": a.proxy(function (a) {
                    a.namespace && "position" === a.property.name && this._playing && this.stop()
                }, this),
                "prepared.owl.carousel": a.proxy(function (b) {
                    if (b.namespace) {
                        var c = a(b.content).find(".owl-video");
                        c.length && (c.css("display", "none"), this.fetch(c, a(b.content)))
                    }
                }, this)
            }, this._core.options = a.extend({}, e.Defaults, this._core.options), this._core.$element.on(this._handlers), this._core.$element.on("click.owl.video", ".owl-video-play-icon", a.proxy(function (a) {
                this.play(a)
            }, this))
        };
        e.Defaults = {
            video: !1,
            videoHeight: !1,
            videoWidth: !1
        }, e.prototype.fetch = function (a, b) {
            var c = a.attr("data-vimeo-id") ? "vimeo" : "youtube",
                d = a.attr("data-vimeo-id") || a.attr("data-youtube-id"),
                e = a.attr("data-width") || this._core.settings.videoWidth,
                f = a.attr("data-height") || this._core.settings.videoHeight,
                g = a.attr("href");
            if (!g) throw new Error("Missing video URL.");
            if (d = g.match(/(http:|https:|)\/\/(player.|www.)?(vimeo\.com|youtu(be\.com|\.be|be\.googleapis\.com))\/(video\/|embed\/|watch\?v=|v\/)?([A-Za-z0-9._%-]*)(\&\S+)?/), d[3].indexOf("youtu") > -1) c = "youtube";
            else {
                if (!(d[3].indexOf("vimeo") > -1)) throw new Error("Video URL not supported.");
                c = "vimeo"
            }
            d = d[6], this._videos[g] = {
                type: c,
                id: d,
                width: e,
                height: f
            }, b.attr("data-video", g), this.thumbnail(a, this._videos[g])
        }, e.prototype.thumbnail = function (b, c) {
            var d, e, f, g = c.width && c.height ? 'style="width:' + c.width + "px;height:" + c.height + 'px;"' : "",
                h = b.find("img"),
                i = "src",
                j = "",
                k = this._core.settings,
                l = function (a) {
                    e = '<div class="owl-video-play-icon"></div>', d = k.lazyLoad ? '<div class="owl-video-tn ' + j + '" ' + i + '="' + a + '"></div>' : '<div class="owl-video-tn" style="opacity:1;background-image:url(' + a + ')"></div>', b.after(d), b.after(e)
                };
            return b.wrap('<div class="owl-video-wrapper"' + g + "></div>"), this._core.settings.lazyLoad && (i = "data-src", j = "owl-lazy"), h.length ? (l(h.attr(i)), h.remove(), !1) : void ("youtube" === c.type ? (f = "http://img.youtube.com/vi/" + c.id + "/hqdefault.jpg", l(f)) : "vimeo" === c.type && a.ajax({
                type: "GET",
                url: "http://vimeo.com/api/v2/video/" + c.id + ".json",
                jsonp: "callback",
                dataType: "jsonp",
                success: function (a) {
                    f = a[0].thumbnail_large, l(f)
                }
            }))
        }, e.prototype.stop = function () {
            this._core.trigger("stop", null, "video"), this._playing.find(".owl-video-frame").remove(), this._playing.removeClass("owl-video-playing"), this._playing = null, this._core.leave("playing"), this._core.trigger("stopped", null, "video")
        }, e.prototype.play = function (b) {
            var h, c = a(b.target),
                d = c.closest("." + this._core.settings.itemClass),
                e = this._videos[d.attr("data-video")],
                f = e.width || "100%",
                g = e.height || this._core.$stage.height();
            this._playing || (this._core.enter("playing"), this._core.trigger("play", null, "video"), d = this._core.items(this._core.relative(d.index())), this._core.reset(d.index()), "youtube" === e.type ? h = '<iframe width="' + f + '" height="' + g + '" src="http://www.youtube.com/embed/' + e.id + "?autoplay=1&v=" + e.id + '" frameborder="0" allowfullscreen></iframe>' : "vimeo" === e.type && (h = '<iframe src="http://player.vimeo.com/video/' + e.id + '?autoplay=1" width="' + f + '" height="' + g + '" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>'), a('<div class="owl-video-frame">' + h + "</div>").insertAfter(d.find(".owl-video")), this._playing = d.addClass("owl-video-playing"))
        }, e.prototype.isInFullScreen = function () {
            var b = c.fullscreenElement || c.mozFullScreenElement || c.webkitFullscreenElement;
            return b && a(b).parent().hasClass("owl-video-frame")
        }, e.prototype.destroy = function () {
            var a, b;
            this._core.$element.off("click.owl.video");
            for (a in this._handlers) this._core.$element.off(a, this._handlers[a]);
            for (b in Object.getOwnPropertyNames(this)) "function" != typeof this[b] && (this[b] = null)
        }, a.fn.owlCarousel.Constructor.Plugins.Video = e
    }(window.Zepto || window.jQuery, window, document),
    function (a, b, c, d) {
        var e = function (b) {
            this.core = b, this.core.options = a.extend({}, e.Defaults, this.core.options), this.swapping = !0, this.previous = d, this.next = d, this.handlers = {
                "change.owl.carousel": a.proxy(function (a) {
                    a.namespace && "position" == a.property.name && (this.previous = this.core.current(), this.next = a.property.value)
                }, this),
                "drag.owl.carousel dragged.owl.carousel translated.owl.carousel": a.proxy(function (a) {
                    a.namespace && (this.swapping = "translated" == a.type)
                }, this),
                "translate.owl.carousel": a.proxy(function (a) {
                    a.namespace && this.swapping && (this.core.options.animateOut || this.core.options.animateIn) && this.swap()
                }, this)
            }, this.core.$element.on(this.handlers)
        };
        e.Defaults = {
            animateOut: !1,
            animateIn: !1
        }, e.prototype.swap = function () {
            if (1 === this.core.settings.items && a.support.animation && a.support.transition) {
                this.core.speed(0);
                var b, c = a.proxy(this.clear, this),
                    d = this.core.$stage.children().eq(this.previous),
                    e = this.core.$stage.children().eq(this.next),
                    f = this.core.settings.animateIn,
                    g = this.core.settings.animateOut;
                this.core.current() !== this.previous && (g && (b = this.core.coordinates(this.previous) - this.core.coordinates(this.next), d.one(a.support.animation.end, c).css({
                    left: b + "px"
                }).addClass("animated owl-animated-out").addClass(g)), f && e.one(a.support.animation.end, c).addClass("animated owl-animated-in").addClass(f))
            }
        }, e.prototype.clear = function (b) {
            a(b.target).css({
                left: ""
            }).removeClass("animated owl-animated-out owl-animated-in").removeClass(this.core.settings.animateIn).removeClass(this.core.settings.animateOut), this.core.onTransitionEnd()
        }, e.prototype.destroy = function () {
            var a, b;
            for (a in this.handlers) this.core.$element.off(a, this.handlers[a]);
            for (b in Object.getOwnPropertyNames(this)) "function" != typeof this[b] && (this[b] = null)
        }, a.fn.owlCarousel.Constructor.Plugins.Animate = e
    }(window.Zepto || window.jQuery, window, document),
    function (a, b, c, d) {
        var e = function (b) {
            this._core = b, this._interval = null, this._paused = !1, this._handlers = {
                "changed.owl.carousel": a.proxy(function (a) {
                    a.namespace && "settings" === a.property.name && (this._core.settings.autoplay ? this.play() : this.stop())
                }, this),
                "initialized.owl.carousel": a.proxy(function (a) {
                    a.namespace && this._core.settings.autoplay && this.play()
                }, this),
                "play.owl.autoplay": a.proxy(function (a, b, c) {
                    a.namespace && this.play(b, c)
                }, this),
                "stop.owl.autoplay": a.proxy(function (a) {
                    a.namespace && this.stop()
                }, this),
                "mouseover.owl.autoplay": a.proxy(function () {
                    this._core.settings.autoplayHoverPause && this._core.is("rotating") && this.pause()
                }, this),
                "mouseleave.owl.autoplay": a.proxy(function () {
                    this._core.settings.autoplayHoverPause && this._core.is("rotating") && this.play()
                }, this)
            }, this._core.$element.on(this._handlers), this._core.options = a.extend({}, e.Defaults, this._core.options)
        };
        e.Defaults = {
            autoplay: !1,
            autoplayTimeout: 5e3,
            autoplayHoverPause: !1,
            autoplaySpeed: !1
        }, e.prototype.play = function (d, e) {
            this._paused = !1, this._core.is("rotating") || (this._core.enter("rotating"), this._interval = b.setInterval(a.proxy(function () {
                this._paused || this._core.is("busy") || this._core.is("interacting") || c.hidden || this._core.next(e || this._core.settings.autoplaySpeed)
            }, this), d || this._core.settings.autoplayTimeout))
        }, e.prototype.stop = function () {
            this._core.is("rotating") && (b.clearInterval(this._interval), this._core.leave("rotating"))
        }, e.prototype.pause = function () {
            this._core.is("rotating") && (this._paused = !0)
        }, e.prototype.destroy = function () {
            var a, b;
            this.stop();
            for (a in this._handlers) this._core.$element.off(a, this._handlers[a]);
            for (b in Object.getOwnPropertyNames(this)) "function" != typeof this[b] && (this[b] = null)
        }, a.fn.owlCarousel.Constructor.Plugins.autoplay = e
    }(window.Zepto || window.jQuery, window, document),
    function (a, b, c, d) {
        "use strict";
        var e = function (b) {
            this._core = b, this._initialized = !1, this._pages = [], this._controls = {}, this._templates = [], this.$element = this._core.$element, this._overrides = {
                next: this._core.next,
                prev: this._core.prev,
                to: this._core.to
            }, this._handlers = {
                "prepared.owl.carousel": a.proxy(function (b) {
                    b.namespace && this._core.settings.dotsData && this._templates.push('<div class="' + this._core.settings.dotClass + '">' + a(b.content).find("[data-dot]").andSelf("[data-dot]").attr("data-dot") + "</div>")
                }, this),
                "added.owl.carousel": a.proxy(function (a) {
                    a.namespace && this._core.settings.dotsData && this._templates.splice(a.position, 0, this._templates.pop())
                }, this),
                "remove.owl.carousel": a.proxy(function (a) {
                    a.namespace && this._core.settings.dotsData && this._templates.splice(a.position, 1)
                }, this),
                "changed.owl.carousel": a.proxy(function (a) {
                    a.namespace && "position" == a.property.name && this.draw()
                }, this),
                "initialized.owl.carousel": a.proxy(function (a) {
                    a.namespace && !this._initialized && (this._core.trigger("initialize", null, "navigation"), this.initialize(), this.update(), this.draw(), this._initialized = !0, this._core.trigger("initialized", null, "navigation"))
                }, this),
                "refreshed.owl.carousel": a.proxy(function (a) {
                    a.namespace && this._initialized && (this._core.trigger("refresh", null, "navigation"), this.update(), this.draw(), this._core.trigger("refreshed", null, "navigation"))
                }, this)
            }, this._core.options = a.extend({}, e.Defaults, this._core.options), this.$element.on(this._handlers)
        };
        e.Defaults = {
            nav: !1,
            navText: ["prev", "next"],
            navSpeed: !1,
            navElement: "div",
            navContainer: !1,
            navContainerClass: "owl-nav",
            navClass: ["owl-prev", "owl-next"],
            slideBy: 1,
            dotClass: "owl-dot",
            dotsClass: "owl-dots",
            dots: !0,
            dotsEach: !1,
            dotsData: !1,
            dotsSpeed: !1,
            dotsContainer: !1
        }, e.prototype.initialize = function () {
            var b, c = this._core.settings;
            this._controls.$relative = (c.navContainer ? a(c.navContainer) : a("<div>").addClass(c.navContainerClass).appendTo(this.$element)).addClass("disabled"), this._controls.$previous = a("<" + c.navElement + ">").addClass(c.navClass[0]).html(c.navText[0]).prependTo(this._controls.$relative).on("click", a.proxy(function (a) {
                this.prev(c.navSpeed)
            }, this)), this._controls.$next = a("<" + c.navElement + ">").addClass(c.navClass[1]).html(c.navText[1]).appendTo(this._controls.$relative).on("click", a.proxy(function (a) {
                this.next(c.navSpeed)
            }, this)), c.dotsData || (this._templates = [a("<div>").addClass(c.dotClass).append(a("<span>")).prop("outerHTML")]), this._controls.$absolute = (c.dotsContainer ? a(c.dotsContainer) : a("<div>").addClass(c.dotsClass).appendTo(this.$element)).addClass("disabled"), this._controls.$absolute.on("click", "div", a.proxy(function (b) {
                var d = a(b.target).parent().is(this._controls.$absolute) ? a(b.target).index() : a(b.target).parent().index();
                b.preventDefault(), this.to(d, c.dotsSpeed)
            }, this));
            for (b in this._overrides) this._core[b] = a.proxy(this[b], this)
        }, e.prototype.destroy = function () {
            var a, b, c, d;
            for (a in this._handlers) this.$element.off(a, this._handlers[a]);
            for (b in this._controls) this._controls[b].remove();
            for (d in this.overides) this._core[d] = this._overrides[d];
            for (c in Object.getOwnPropertyNames(this)) "function" != typeof this[c] && (this[c] = null)
        }, e.prototype.update = function () {
            var a, b, c, d = this._core.clones().length / 2,
                e = d + this._core.items().length,
                f = this._core.maximum(!0),
                g = this._core.settings,
                h = g.center || g.autoWidth || g.dotsData ? 1 : g.dotsEach || g.items;
            if ("page" !== g.slideBy && (g.slideBy = Math.min(g.slideBy, g.items)), g.dots || "page" == g.slideBy)
                for (this._pages = [], a = d, b = 0, c = 0; a < e; a++) {
                    if (b >= h || 0 === b) {
                        if (this._pages.push({
                            start: Math.min(f, a - d),
                            end: a - d + h - 1
                        }), Math.min(f, a - d) === f) break;
                        b = 0, ++c
                    }
                    b += this._core.mergers(this._core.relative(a))
                }
        }, e.prototype.draw = function () {
            var b, c = this._core.settings,
                d = this._core.items().length <= c.items,
                e = this._core.relative(this._core.current()),
                f = c.loop || c.rewind;
            this._controls.$relative.toggleClass("disabled", !c.nav || d), c.nav && (this._controls.$previous.toggleClass("disabled", !f && e <= this._core.minimum(!0)), this._controls.$next.toggleClass("disabled", !f && e >= this._core.maximum(!0))), this._controls.$absolute.toggleClass("disabled", !c.dots || d), c.dots && (b = this._pages.length - this._controls.$absolute.children().length, c.dotsData && 0 !== b ? this._controls.$absolute.html(this._templates.join("")) : b > 0 ? this._controls.$absolute.append(new Array(b + 1).join(this._templates[0])) : b < 0 && this._controls.$absolute.children().slice(b).remove(), this._controls.$absolute.find(".active").removeClass("active"), this._controls.$absolute.children().eq(a.inArray(this.current(), this._pages)).addClass("active"))
        }, e.prototype.onTrigger = function (b) {
            var c = this._core.settings;
            b.page = {
                index: a.inArray(this.current(), this._pages),
                count: this._pages.length,
                size: c && (c.center || c.autoWidth || c.dotsData ? 1 : c.dotsEach || c.items)
            }
        }, e.prototype.current = function () {
            var b = this._core.relative(this._core.current());
            return a.grep(this._pages, a.proxy(function (a, c) {
                return a.start <= b && a.end >= b
            }, this)).pop()
        }, e.prototype.getPosition = function (b) {
            var c, d, e = this._core.settings;
            return "page" == e.slideBy ? (c = a.inArray(this.current(), this._pages), d = this._pages.length, b ? ++c : --c, c = this._pages[(c % d + d) % d].start) : (c = this._core.relative(this._core.current()), d = this._core.items().length, b ? c += e.slideBy : c -= e.slideBy), c
        }, e.prototype.next = function (b) {
            a.proxy(this._overrides.to, this._core)(this.getPosition(!0), b)
        }, e.prototype.prev = function (b) {
            a.proxy(this._overrides.to, this._core)(this.getPosition(!1), b)
        }, e.prototype.to = function (b, c, d) {
            var e;
            d ? a.proxy(this._overrides.to, this._core)(b, c) : (e = this._pages.length, a.proxy(this._overrides.to, this._core)(this._pages[(b % e + e) % e].start, c))
        }, a.fn.owlCarousel.Constructor.Plugins.Navigation = e
    }(window.Zepto || window.jQuery, window, document),
    function (a, b, c, d) {
        "use strict";
        var e = function (c) {
            this._core = c, this._hashes = {}, this.$element = this._core.$element, this._handlers = {
                "initialized.owl.carousel": a.proxy(function (c) {
                    c.namespace && "URLHash" === this._core.settings.startPosition && a(b).trigger("hashchange.owl.navigation")
                }, this),
                "prepared.owl.carousel": a.proxy(function (b) {
                    if (b.namespace) {
                        var c = a(b.content).find("[data-hash]").andSelf("[data-hash]").attr("data-hash");
                        if (!c) return;
                        this._hashes[c] = b.content
                    }
                }, this),
                "changed.owl.carousel": a.proxy(function (c) {
                    if (c.namespace && "position" === c.property.name) {
                        var d = this._core.items(this._core.relative(this._core.current())),
                            e = a.map(this._hashes, function (a, b) {
                                return a === d ? b : null
                            }).join();
                        if (!e || b.location.hash.slice(1) === e) return;
                        b.location.hash = e
                    }
                }, this)
            }, this._core.options = a.extend({}, e.Defaults, this._core.options), this.$element.on(this._handlers), a(b).on("hashchange.owl.navigation", a.proxy(function (a) {
                var c = b.location.hash.substring(1),
                    e = this._core.$stage.children(),
                    f = this._hashes[c] && e.index(this._hashes[c]);
                f !== d && f !== this._core.current() && this._core.to(this._core.relative(f), !1, !0)
            }, this))
        };
        e.Defaults = {
            URLhashListener: !1
        }, e.prototype.destroy = function () {
            var c, d;
            a(b).off("hashchange.owl.navigation");
            for (c in this._handlers) this._core.$element.off(c, this._handlers[c]);
            for (d in Object.getOwnPropertyNames(this)) "function" != typeof this[d] && (this[d] = null)
        }, a.fn.owlCarousel.Constructor.Plugins.Hash = e
    }(window.Zepto || window.jQuery, window, document),
    function (a, b, c, d) {
        function i(b, c) {
            var g = !1,
                h = b.charAt(0).toUpperCase() + b.slice(1);
            return a.each((b + " " + f.join(h + " ") + h).split(" "), function (a, b) {
                if (e[b] !== d) return g = !c || b, !1
            }), g
        }

        function j(a) {
            return i(a, !0)
        }
        var e = a("<support>").get(0).style,
            f = "Webkit Moz O ms".split(" "),
            g = {
                transition: {
                    end: {
                        WebkitTransition: "webkitTransitionEnd",
                        MozTransition: "transitionend",
                        OTransition: "oTransitionEnd",
                        transition: "transitionend"
                    }
                },
                animation: {
                    end: {
                        WebkitAnimation: "webkitAnimationEnd",
                        MozAnimation: "animationend",
                        OAnimation: "oAnimationEnd",
                        animation: "animationend"
                    }
                }
            },
            h = {
                csstransforms: function () {
                    return !!i("transform")
                },
                csstransforms3d: function () {
                    return !!i("perspective")
                },
                csstransitions: function () {
                    return !!i("transition")
                },
                cssanimations: function () {
                    return !!i("animation")
                }
            };
        h.csstransitions() && (a.support.transition = new String(j("transition")), a.support.transition.end = g.transition.end[a.support.transition]), h.cssanimations() && (a.support.animation = new String(j("animation")), a.support.animation.end = g.animation.end[a.support.animation]), h.csstransforms() && (a.support.transform = new String(j("transform")), a.support.transform3d = h.csstransforms3d())
    }(window.Zepto || window.jQuery, window, document),
    function (a, b, c, d) {
        "use strict";
        var e = c("html"),
            f = c(a),
            g = c(b),
            h = c.fancybox = function () {
                h.open.apply(this, arguments)
            },
            i = navigator.userAgent.match(/msie/i),
            j = null,
            k = b.createTouch !== d,
            l = function (a) {
                return a && a.hasOwnProperty && a instanceof c
            },
            m = function (a) {
                return a && "string" === c.type(a)
            },
            n = function (a) {
                return m(a) && a.indexOf("%") > 0
            },
            o = function (a) {
                return a && !(a.style.overflow && "hidden" === a.style.overflow) && (a.clientWidth && a.scrollWidth > a.clientWidth || a.clientHeight && a.scrollHeight > a.clientHeight)
            },
            p = function (a, b) {
                var c = parseInt(a, 10) || 0;
                return b && n(a) && (c = h.getViewport()[b] / 100 * c), Math.ceil(c)
            },
            q = function (a, b) {
                return p(a, b) + "px"
            };
        c.extend(h, {
            version: "2.1.5",
            defaults: {
                padding: 15,
                margin: 20,
                width: 800,
                height: 600,
                minWidth: 100,
                minHeight: 100,
                maxWidth: 9999,
                maxHeight: 9999,
                pixelRatio: 1,
                autoSize: !0,
                autoHeight: !1,
                autoWidth: !1,
                autoResize: !0,
                autoCenter: !k,
                fitToView: !0,
                aspectRatio: !1,
                topRatio: .5,
                leftRatio: .5,
                scrolling: "auto",
                wrapCSS: "",
                arrows: !0,
                closeBtn: !0,
                closeClick: !1,
                nextClick: !1,
                mouseWheel: !0,
                autoPlay: !1,
                playSpeed: 3e3,
                preload: 3,
                modal: !1,
                loop: !0,
                ajax: {
                    dataType: "html",
                    headers: {
                        "X-fancyBox": !0
                    }
                },
                iframe: {
                    scrolling: "auto",
                    preload: !0
                },
                swf: {
                    wmode: "transparent",
                    allowfullscreen: "true",
                    allowscriptaccess: "always"
                },
                keys: {
                    next: {
                        13: "left",
                        34: "up",
                        39: "left",
                        40: "up"
                    },
                    prev: {
                        8: "right",
                        33: "down",
                        37: "right",
                        38: "down"
                    },
                    close: [27],
                    play: [32],
                    toggle: [70]
                },
                direction: {
                    next: "left",
                    prev: "right"
                },
                scrollOutside: !0,
                index: 0,
                type: null,
                href: null,
                content: null,
                title: null,
                tpl: {
                    wrap: '<div class="fancybox-wrap" tabIndex="-1"><div class="fancybox-skin"><div class="fancybox-outer"><div class="fancybox-inner"></div></div></div></div>',
                    image: '<img class="fancybox-image" src="{href}" alt="" />',
                    iframe: '<iframe id="fancybox-frame{rnd}" name="fancybox-frame{rnd}" class="fancybox-iframe" frameborder="0" vspace="0" hspace="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen' + (i ? ' allowtransparency="true"' : "") + "></iframe>",
                    error: '<p class="fancybox-error">The requested content cannot be loaded.<br/>Please try again later.</p>',
                    closeBtn: '<a title="Close" class="fancybox-item fancybox-close" href="javascript:;"></a>',
                    next: '<a title="Next" class="fancybox-nav fancybox-next" href="javascript:;"><span></span></a>',
                    prev: '<a title="Previous" class="fancybox-nav fancybox-prev" href="javascript:;"><span></span></a>',
                    loading: '<div id="fancybox-loading"><div></div></div>'
                },
                openEffect: "fade",
                openSpeed: 250,
                openEasing: "swing",
                openOpacity: !0,
                openMethod: "zoomIn",
                closeEffect: "fade",
                closeSpeed: 250,
                closeEasing: "swing",
                closeOpacity: !0,
                closeMethod: "zoomOut",
                nextEffect: "elastic",
                nextSpeed: 250,
                nextEasing: "swing",
                nextMethod: "changeIn",
                prevEffect: "elastic",
                prevSpeed: 250,
                prevEasing: "swing",
                prevMethod: "changeOut",
                helpers: {
                    overlay: !0,
                    title: !0
                },
                onCancel: c.noop,
                beforeLoad: c.noop,
                afterLoad: c.noop,
                beforeShow: c.noop,
                afterShow: c.noop,
                beforeChange: c.noop,
                beforeClose: c.noop,
                afterClose: c.noop
            },
            group: {},
            opts: {},
            previous: null,
            coming: null,
            current: null,
            isActive: !1,
            isOpen: !1,
            isOpened: !1,
            wrap: null,
            skin: null,
            outer: null,
            inner: null,
            player: {
                timer: null,
                isActive: !1
            },
            ajaxLoad: null,
            imgPreload: null,
            transitions: {},
            helpers: {},
            open: function (a, b) {
                if (a && (c.isPlainObject(b) || (b = {}), !1 !== h.close(!0))) return c.isArray(a) || (a = l(a) ? c(a).get() : [a]), c.each(a, function (e, f) {
                    var i, j, k, n, o, p, q, g = {};
                    "object" === c.type(f) && (f.nodeType && (f = c(f)), l(f) ? (g = {
                        href: f.data("fancybox-href") || f.attr("href"),
                        title: c("<div/>").text(f.data("fancybox-title") || f.attr("title") || "").html(),
                        isDom: !0,
                        element: f
                    }, c.metadata && c.extend(!0, g, f.metadata())) : g = f), i = b.href || g.href || (m(f) ? f : null), j = b.title !== d ? b.title : g.title || "", k = b.content || g.content, n = k ? "html" : b.type || g.type, !n && g.isDom && (n = f.data("fancybox-type"), n || (o = f.prop("class").match(/fancybox\.(\w+)/), n = o ? o[1] : null)), m(i) && (n || (h.isImage(i) ? n = "image" : h.isSWF(i) ? n = "swf" : "#" === i.charAt(0) ? n = "inline" : m(f) && (n = "html", k = f)), "ajax" === n && (p = i.split(/\s+/, 2), i = p.shift(), q = p.shift())), k || ("inline" === n ? i ? k = c(m(i) ? i.replace(/.*(?=#[^\s]+$)/, "") : i) : g.isDom && (k = f) : "html" === n ? k = i : n || i || !g.isDom || (n = "inline", k = f)), c.extend(g, {
                        href: i,
                        type: n,
                        content: k,
                        title: j,
                        selector: q
                    }), a[e] = g
                }), h.opts = c.extend(!0, {}, h.defaults, b), b.keys !== d && (h.opts.keys = !!b.keys && c.extend({}, h.defaults.keys, b.keys)), h.group = a, h._start(h.opts.index)
            },
            cancel: function () {
                var a = h.coming;
                a && !1 === h.trigger("onCancel") || (h.hideLoading(), a && (h.ajaxLoad && h.ajaxLoad.abort(), h.ajaxLoad = null, h.imgPreload && (h.imgPreload.onload = h.imgPreload.onerror = null), a.wrap && a.wrap.stop(!0, !0).trigger("onReset").remove(), h.coming = null, h.current || h._afterZoomOut(a)))
            },
            close: function (a) {
                h.cancel(), !1 !== h.trigger("beforeClose") && (h.unbindEvents(), h.isActive && (h.isOpen && a !== !0 ? (h.isOpen = h.isOpened = !1, h.isClosing = !0, c(".fancybox-item, .fancybox-nav").remove(), h.wrap.stop(!0, !0).removeClass("fancybox-opened"), h.transitions[h.current.closeMethod]()) : (c(".fancybox-wrap").stop(!0).trigger("onReset").remove(), h._afterZoomOut())))
            },
            play: function (a) {
                var b = function () {
                    clearTimeout(h.player.timer)
                },
                    c = function () {
                        b(), h.current && h.player.isActive && (h.player.timer = setTimeout(h.next, h.current.playSpeed))
                    },
                    d = function () {
                        b(), g.unbind(".player"), h.player.isActive = !1, h.trigger("onPlayEnd")
                    },
                    e = function () {
                        h.current && (h.current.loop || h.current.index < h.group.length - 1) && (h.player.isActive = !0, g.bind({
                            "onCancel.player beforeClose.player": d,
                            "onUpdate.player": c,
                            "beforeLoad.player": b
                        }), c(), h.trigger("onPlayStart"))
                    };
                a === !0 || !h.player.isActive && a !== !1 ? e() : d()
            },
            next: function (a) {
                var b = h.current;
                b && (m(a) || (a = b.direction.next), h.jumpto(b.index + 1, a, "next"))
            },
            prev: function (a) {
                var b = h.current;
                b && (m(a) || (a = b.direction.prev), h.jumpto(b.index - 1, a, "prev"))
            },
            jumpto: function (a, b, c) {
                var e = h.current;
                e && (a = p(a), h.direction = b || e.direction[a >= e.index ? "next" : "prev"], h.router = c || "jumpto", e.loop && (a < 0 && (a = e.group.length + a % e.group.length), a %= e.group.length), e.group[a] !== d && (h.cancel(), h._start(a)))
            },
            reposition: function (a, b) {
                var f, d = h.current,
                    e = d ? d.wrap : null;
                e && (f = h._getPosition(b), a && "scroll" === a.type ? (delete f.position, e.stop(!0, !0).animate(f, 200)) : (e.css(f), d.pos = c.extend({}, d.dim, f)))
            },
            update: function (a) {
                var b = a && a.originalEvent && a.originalEvent.type,
                    c = !b || "orientationchange" === b;
                c && (clearTimeout(j), j = null), h.isOpen && !j && (j = setTimeout(function () {
                    var d = h.current;
                    d && !h.isClosing && (h.wrap.removeClass("fancybox-tmp"), (c || "load" === b || "resize" === b && d.autoResize) && h._setDimension(), "scroll" === b && d.canShrink || h.reposition(a), h.trigger("onUpdate"), j = null)
                }, c && !k ? 0 : 300))
            },
            toggle: function (a) {
                h.isOpen && (h.current.fitToView = "boolean" === c.type(a) ? a : !h.current.fitToView, k && (h.wrap.removeAttr("style").addClass("fancybox-tmp"), h.trigger("onUpdate")), h.update())
            },
            hideLoading: function () {
                g.unbind(".loading"), c("#fancybox-loading").remove()
            },
            showLoading: function () {
                var a, b;
                h.hideLoading(), a = c(h.opts.tpl.loading).click(h.cancel).appendTo("body"), g.bind("keydown.loading", function (a) {
                    27 === (a.which || a.keyCode) && (a.preventDefault(), h.cancel())
                }), h.defaults.fixed || (b = h.getViewport(), a.css({
                    position: "absolute",
                    top: .5 * b.h + b.y,
                    left: .5 * b.w + b.x
                })), h.trigger("onLoading")
            },
            getViewport: function () {
                var b = h.current && h.current.locked || !1,
                    c = {
                        x: f.scrollLeft(),
                        y: f.scrollTop()
                    };
                return b && b.length ? (c.w = b[0].clientWidth, c.h = b[0].clientHeight) : (c.w = k && a.innerWidth ? a.innerWidth : f.width(),
                    c.h = k && a.innerHeight ? a.innerHeight : f.height()), c
            },
            unbindEvents: function () {
                h.wrap && l(h.wrap) && h.wrap.unbind(".fb"), g.unbind(".fb"), f.unbind(".fb")
            },
            bindEvents: function () {
                var b, a = h.current;
                a && (f.bind("orientationchange.fb" + (k ? "" : " resize.fb") + (a.autoCenter && !a.locked ? " scroll.fb" : ""), h.update), b = a.keys, b && g.bind("keydown.fb", function (e) {
                    var f = e.which || e.keyCode,
                        g = e.target || e.srcElement;
                    return (27 !== f || !h.coming) && void (e.ctrlKey || e.altKey || e.shiftKey || e.metaKey || g && (g.type || c(g).is("[contenteditable]")) || c.each(b, function (b, g) {
                        return a.group.length > 1 && g[f] !== d ? (h[b](g[f]), e.preventDefault(), !1) : c.inArray(f, g) > -1 ? (h[b](), e.preventDefault(), !1) : void 0
                    }))
                }), c.fn.mousewheel && a.mouseWheel && h.wrap.bind("mousewheel.fb", function (b, d, e, f) {
                    for (var g = b.target || null, i = c(g), j = !1; i.length && !(j || i.is(".fancybox-skin") || i.is(".fancybox-wrap"));) j = o(i[0]), i = c(i).parent();
                    0 === d || j || h.group.length > 1 && !a.canShrink && (f > 0 || e > 0 ? h.prev(f > 0 ? "down" : "left") : (f < 0 || e < 0) && h.next(f < 0 ? "up" : "right"), b.preventDefault())
                }))
            },
            trigger: function (a, b) {
                var d, e = b || h.coming || h.current;
                if (e) {
                    if (c.isFunction(e[a]) && (d = e[a].apply(e, Array.prototype.slice.call(arguments, 1))), d === !1) return !1;
                    e.helpers && c.each(e.helpers, function (b, d) {
                        d && h.helpers[b] && c.isFunction(h.helpers[b][a]) && h.helpers[b][a](c.extend(!0, {}, h.helpers[b].defaults, d), e)
                    })
                }
                g.trigger(a)
            },
            isImage: function (a) {
                return m(a) && a.match(/(^data:image\/.*,)|(\.(jp(e|g|eg)|gif|png|bmp|webp|svg)((\?|#).*)?$)/i)
            },
            isSWF: function (a) {
                return m(a) && a.match(/\.(swf)((\?|#).*)?$/i)
            },
            _start: function (a) {
                var d, e, f, g, i, b = {};
                if (a = p(a), d = h.group[a] || null, !d) return !1;
                if (b = c.extend(!0, {}, h.opts, d), g = b.margin, i = b.padding, "number" === c.type(g) && (b.margin = [g, g, g, g]), "number" === c.type(i) && (b.padding = [i, i, i, i]), b.modal && c.extend(!0, b, {
                    closeBtn: !1,
                    closeClick: !1,
                    nextClick: !1,
                    arrows: !1,
                    mouseWheel: !1,
                    keys: null,
                    helpers: {
                        overlay: {
                            closeClick: !1
                        }
                    }
                }), b.autoSize && (b.autoWidth = b.autoHeight = !0), "auto" === b.width && (b.autoWidth = !0), "auto" === b.height && (b.autoHeight = !0), b.group = h.group, b.index = a, h.coming = b, !1 === h.trigger("beforeLoad")) return void (h.coming = null);
                if (f = b.type, e = b.href, !f) return h.coming = null, !(!h.current || !h.router || "jumpto" === h.router) && (h.current.index = a, h[h.router](h.direction));
                if (h.isActive = !0, "image" !== f && "swf" !== f || (b.autoHeight = b.autoWidth = !1, b.scrolling = "visible"), "image" === f && (b.aspectRatio = !0), "iframe" === f && k && (b.scrolling = "scroll"), b.wrap = c(b.tpl.wrap).addClass("fancybox-" + (k ? "mobile" : "desktop") + " fancybox-type-" + f + " fancybox-tmp " + b.wrapCSS).appendTo(b.parent || "body"), c.extend(b, {
                    skin: c(".fancybox-skin", b.wrap),
                    outer: c(".fancybox-outer", b.wrap),
                    inner: c(".fancybox-inner", b.wrap)
                }), c.each(["Top", "Right", "Bottom", "Left"], function (a, c) {
                    b.skin.css("padding" + c, q(b.padding[a]))
                }), h.trigger("onReady"), "inline" === f || "html" === f) {
                    if (!b.content || !b.content.length) return h._error("content")
                } else if (!e) return h._error("href");
                "image" === f ? h._loadImage() : "ajax" === f ? h._loadAjax() : "iframe" === f ? h._loadIframe() : h._afterLoad()
            },
            _error: function (a) {
                c.extend(h.coming, {
                    type: "html",
                    autoWidth: !0,
                    autoHeight: !0,
                    minWidth: 0,
                    minHeight: 0,
                    scrolling: "no",
                    hasError: a,
                    content: h.coming.tpl.error
                }), h._afterLoad()
            },
            _loadImage: function () {
                var a = h.imgPreload = new Image;
                a.onload = function () {
                    this.onload = this.onerror = null, h.coming.width = this.width / h.opts.pixelRatio, h.coming.height = this.height / h.opts.pixelRatio, h._afterLoad()
                }, a.onerror = function () {
                    this.onload = this.onerror = null, h._error("image")
                }, a.src = h.coming.href, a.complete !== !0 && h.showLoading()
            },
            _loadAjax: function () {
                var a = h.coming;
                h.showLoading(), h.ajaxLoad = c.ajax(c.extend({}, a.ajax, {
                    url: a.href,
                    error: function (a, b) {
                        h.coming && "abort" !== b ? h._error("ajax", a) : h.hideLoading()
                    },
                    success: function (b, c) {
                        "success" === c && (a.content = b, h._afterLoad())
                    }
                }))
            },
            _loadIframe: function () {
                var a = h.coming,
                    b = c(a.tpl.iframe.replace(/\{rnd\}/g, (new Date).getTime())).attr("scrolling", k ? "auto" : a.iframe.scrolling).attr("src", a.href);
                c(a.wrap).bind("onReset", function () {
                    try {
                        c(this).find("iframe").hide().attr("src", "//about:blank").end().empty()
                    } catch (a) { }
                }), a.iframe.preload && (h.showLoading(), b.one("load", function () {
                    c(this).data("ready", 1), k || c(this).bind("load.fb", h.update), c(this).parents(".fancybox-wrap").width("100%").removeClass("fancybox-tmp").show(), h._afterLoad()
                })), a.content = b.appendTo(a.inner), a.iframe.preload || h._afterLoad()
            },
            _preloadImages: function () {
                var e, f, a = h.group,
                    b = h.current,
                    c = a.length,
                    d = b.preload ? Math.min(b.preload, c - 1) : 0;
                for (f = 1; f <= d; f += 1) e = a[(b.index + f) % c], "image" === e.type && e.href && ((new Image).src = e.href)
            },
            _afterLoad: function () {
                var e, f, g, i, j, k, a = h.coming,
                    b = h.current,
                    d = "fancybox-placeholder";
                if (h.hideLoading(), a && h.isActive !== !1) {
                    if (!1 === h.trigger("afterLoad", a, b)) return a.wrap.stop(!0).trigger("onReset").remove(), void (h.coming = null);
                    switch (b && (h.trigger("beforeChange", b), b.wrap.stop(!0).removeClass("fancybox-opened").find(".fancybox-item, .fancybox-nav").remove()), h.unbindEvents(), e = a, f = a.content, g = a.type, i = a.scrolling, c.extend(h, {
                        wrap: e.wrap,
                        skin: e.skin,
                        outer: e.outer,
                        inner: e.inner,
                        current: e,
                        previous: b
                    }), j = e.href, g) {
                        case "inline":
                        case "ajax":
                        case "html":
                            e.selector ? f = c("<div>").html(f).find(e.selector) : l(f) && (f.data(d) || f.data(d, c('<div class="' + d + '"></div>').insertAfter(f).hide()), f = f.show().detach(), e.wrap.bind("onReset", function () {
                                c(this).find(f).length && f.hide().replaceAll(f.data(d)).data(d, !1)
                            }));
                            break;
                        case "image":
                            f = e.tpl.image.replace(/\{href\}/g, j);
                            break;
                        case "swf":
                            f = '<object id="fancybox-swf" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="100%" height="100%"><param name="movie" value="' + j + '"></param>', k = "", c.each(e.swf, function (a, b) {
                                f += '<param name="' + a + '" value="' + b + '"></param>', k += " " + a + '="' + b + '"'
                            }), f += '<embed src="' + j + '" type="application/x-shockwave-flash" width="100%" height="100%"' + k + "></embed></object>"
                    }
                    l(f) && f.parent().is(e.inner) || e.inner.append(f), h.trigger("beforeShow"), e.inner.css("overflow", "yes" === i ? "scroll" : "no" === i ? "hidden" : i), h._setDimension(), h.reposition(), h.isOpen = !1, h.coming = null, h.bindEvents(), h.isOpened ? b.prevMethod && h.transitions[b.prevMethod]() : c(".fancybox-wrap").not(e.wrap).stop(!0).trigger("onReset").remove(), h.transitions[h.isOpened ? e.nextMethod : e.openMethod](), h._preloadImages()
                }
            },
            _setDimension: function () {
                var y, z, A, B, C, D, E, F, G, H, I, J, K, L, M, a = h.getViewport(),
                    b = 0,
                    d = !1,
                    e = !1,
                    f = h.wrap,
                    g = h.skin,
                    i = h.inner,
                    j = h.current,
                    k = j.width,
                    l = j.height,
                    m = j.minWidth,
                    o = j.minHeight,
                    r = j.maxWidth,
                    s = j.maxHeight,
                    t = j.scrolling,
                    u = j.scrollOutside ? j.scrollbarWidth : 0,
                    v = j.margin,
                    w = p(v[1] + v[3]),
                    x = p(v[0] + v[2]);
                if (f.add(g).add(i).width("auto").height("auto").removeClass("fancybox-tmp"), y = p(g.outerWidth(!0) - g.width()), z = p(g.outerHeight(!0) - g.height()), A = w + y, B = x + z, C = n(k) ? (a.w - A) * p(k) / 100 : k, D = n(l) ? (a.h - B) * p(l) / 100 : l, "iframe" === j.type) {
                    if (L = j.content, j.autoHeight && 1 === L.data("ready")) try {
                        L[0].contentWindow.document.location && (i.width(C).height(9999), M = L.contents().find("body"), u && M.css("overflow-x", "hidden"), D = M.outerHeight(!0))
                    } catch (a) { }
                } else (j.autoWidth || j.autoHeight) && (i.addClass("fancybox-tmp"), j.autoWidth || i.width(C), j.autoHeight || i.height(D), j.autoWidth && (C = i.width()), j.autoHeight && (D = i.height()), i.removeClass("fancybox-tmp"));
                if (k = p(C), l = p(D), G = C / D, m = p(n(m) ? p(m, "w") - A : m), r = p(n(r) ? p(r, "w") - A : r), o = p(n(o) ? p(o, "h") - B : o), s = p(n(s) ? p(s, "h") - B : s), E = r, F = s, j.fitToView && (r = Math.min(a.w - A, r), s = Math.min(a.h - B, s)), J = a.w - w, K = a.h - x, j.aspectRatio ? (k > r && (k = r, l = p(k / G)), l > s && (l = s, k = p(l * G)), k < m && (k = m, l = p(k / G)), l < o && (l = o, k = p(l * G))) : (k = Math.max(m, Math.min(k, r)), j.autoHeight && "iframe" !== j.type && (i.width(k), l = i.height()), l = Math.max(o, Math.min(l, s))), j.fitToView)
                    if (i.width(k).height(l), f.width(k + y), H = f.width(), I = f.height(), j.aspectRatio)
                        for (;
                            (H > J || I > K) && k > m && l > o && !(b++ > 19);) l = Math.max(o, Math.min(s, l - 10)), k = p(l * G), k < m && (k = m, l = p(k / G)), k > r && (k = r, l = p(k / G)), i.width(k).height(l), f.width(k + y), H = f.width(), I = f.height();
                    else k = Math.max(m, Math.min(k, k - (H - J))), l = Math.max(o, Math.min(l, l - (I - K)));
                u && "auto" === t && l < D && k + y + u < J && (k += u), i.width(k).height(l), f.width(k + y), H = f.width(), I = f.height(), d = (H > J || I > K) && k > m && l > o, e = j.aspectRatio ? k < E && l < F && k < C && l < D : (k < E || l < F) && (k < C || l < D), c.extend(j, {
                    dim: {
                        width: q(H),
                        height: q(I)
                    },
                    origWidth: C,
                    origHeight: D,
                    canShrink: d,
                    canExpand: e,
                    wPadding: y,
                    hPadding: z,
                    wrapSpace: I - g.outerHeight(!0),
                    skinSpace: g.height() - l
                }), !L && j.autoHeight && l > o && l < s && !e && i.height("auto")
            },
            _getPosition: function (a) {
                var b = h.current,
                    c = h.getViewport(),
                    d = b.margin,
                    e = h.wrap.width() + d[1] + d[3],
                    f = h.wrap.height() + d[0] + d[2],
                    g = {
                        position: "absolute",
                        top: d[0],
                        left: d[3]
                    };
                return b.autoCenter && b.fixed && !a && f <= c.h && e <= c.w ? g.position = "fixed" : b.locked || (g.top += c.y, g.left += c.x), g.top = q(Math.max(g.top, g.top + (c.h - f) * b.topRatio)), g.left = q(Math.max(g.left, g.left + (c.w - e) * b.leftRatio)), g
            },
            _afterZoomIn: function () {
                var a = h.current;
                a && (h.isOpen = h.isOpened = !0, h.wrap.css("overflow", "visible").addClass("fancybox-opened").hide().show(0), h.update(), (a.closeClick || a.nextClick && h.group.length > 1) && h.inner.css("cursor", "pointer").bind("click.fb", function (b) {
                    c(b.target).is("a") || c(b.target).parent().is("a") || (b.preventDefault(), h[a.closeClick ? "close" : "next"]())
                }), a.closeBtn && c(a.tpl.closeBtn).appendTo(h.skin).bind("click.fb", function (a) {
                    a.preventDefault(), h.close()
                }), a.arrows && h.group.length > 1 && ((a.loop || a.index > 0) && c(a.tpl.prev).appendTo(h.outer).bind("click.fb", h.prev), (a.loop || a.index < h.group.length - 1) && c(a.tpl.next).appendTo(h.outer).bind("click.fb", h.next)), h.trigger("afterShow"), a.loop || a.index !== a.group.length - 1 ? h.opts.autoPlay && !h.player.isActive && (h.opts.autoPlay = !1, h.play(!0)) : h.play(!1))
            },
            _afterZoomOut: function (a) {
                a = a || h.current, c(".fancybox-wrap").trigger("onReset").remove(), c.extend(h, {
                    group: {},
                    opts: {},
                    router: !1,
                    current: null,
                    isActive: !1,
                    isOpened: !1,
                    isOpen: !1,
                    isClosing: !1,
                    wrap: null,
                    skin: null,
                    outer: null,
                    inner: null
                }), h.trigger("afterClose", a)
            }
        }), h.transitions = {
            getOrigPosition: function () {
                var a = h.current,
                    b = a.element,
                    c = a.orig,
                    d = {},
                    e = 50,
                    f = 50,
                    g = a.hPadding,
                    i = a.wPadding,
                    j = h.getViewport();
                return !c && a.isDom && b.is(":visible") && (c = b.find("img:first"), c.length || (c = b)), l(c) ? (d = c.offset(), c.is("img") && (e = c.outerWidth(), f = c.outerHeight())) : (d.top = j.y + (j.h - f) * a.topRatio, d.left = j.x + (j.w - e) * a.leftRatio), ("fixed" === h.wrap.css("position") || a.locked) && (d.top -= j.y, d.left -= j.x), d = {
                    top: q(d.top - g * a.topRatio),
                    left: q(d.left - i * a.leftRatio),
                    width: q(e + i),
                    height: q(f + g)
                }
            },
            step: function (a, b) {
                var c, d, e, f = b.prop,
                    g = h.current,
                    i = g.wrapSpace,
                    j = g.skinSpace;
                "width" !== f && "height" !== f || (c = b.end === b.start ? 1 : (a - b.start) / (b.end - b.start), h.isClosing && (c = 1 - c), d = "width" === f ? g.wPadding : g.hPadding, e = a - d, h.skin[f](p("width" === f ? e : e - i * c)), h.inner[f](p("width" === f ? e : e - i * c - j * c)))
            },
            zoomIn: function () {
                var a = h.current,
                    b = a.pos,
                    d = a.openEffect,
                    e = "elastic" === d,
                    f = c.extend({
                        opacity: 1
                    }, b);
                delete f.position, e ? (b = this.getOrigPosition(), a.openOpacity && (b.opacity = .1)) : "fade" === d && (b.opacity = .1), h.wrap.css(b).animate(f, {
                    duration: "none" === d ? 0 : a.openSpeed,
                    easing: a.openEasing,
                    step: e ? this.step : null,
                    complete: h._afterZoomIn
                })
            },
            zoomOut: function () {
                var a = h.current,
                    b = a.closeEffect,
                    c = "elastic" === b,
                    d = {
                        opacity: .1
                    };
                c && (d = this.getOrigPosition(), a.closeOpacity && (d.opacity = .1)), h.wrap.animate(d, {
                    duration: "none" === b ? 0 : a.closeSpeed,
                    easing: a.closeEasing,
                    step: c ? this.step : null,
                    complete: h._afterZoomOut
                })
            },
            changeIn: function () {
                var g, a = h.current,
                    b = a.nextEffect,
                    c = a.pos,
                    d = {
                        opacity: 1
                    },
                    e = h.direction,
                    f = 200;
                c.opacity = .1, "elastic" === b && (g = "down" === e || "up" === e ? "top" : "left", "down" === e || "right" === e ? (c[g] = q(p(c[g]) - f), d[g] = "+=" + f + "px") : (c[g] = q(p(c[g]) + f), d[g] = "-=" + f + "px")), "none" === b ? h._afterZoomIn() : h.wrap.css(c).animate(d, {
                    duration: a.nextSpeed,
                    easing: a.nextEasing,
                    complete: h._afterZoomIn
                })
            },
            changeOut: function () {
                var a = h.previous,
                    b = a.prevEffect,
                    d = {
                        opacity: .1
                    },
                    e = h.direction,
                    f = 200;
                "elastic" === b && (d["down" === e || "up" === e ? "top" : "left"] = ("up" === e || "left" === e ? "-" : "+") + "=" + f + "px"), a.wrap.animate(d, {
                    duration: "none" === b ? 0 : a.prevSpeed,
                    easing: a.prevEasing,
                    complete: function () {
                        c(this).trigger("onReset").remove()
                    }
                })
            }
        }, h.helpers.overlay = {
            defaults: {
                closeClick: !0,
                speedOut: 200,
                showEarly: !0,
                css: {},
                locked: !k,
                fixed: !0
            },
            overlay: null,
            fixed: !1,
            el: c("html"),
            create: function (a) {
                var b;
                a = c.extend({}, this.defaults, a), this.overlay && this.close(), b = h.coming ? h.coming.parent : a.parent, this.overlay = c('<div class="fancybox-overlay"></div>').appendTo(b && b.length ? b : "body"), this.fixed = !1, a.fixed && h.defaults.fixed && (this.overlay.addClass("fancybox-overlay-fixed"), this.fixed = !0)
            },
            open: function (a) {
                var b = this;
                a = c.extend({}, this.defaults, a), this.overlay ? this.overlay.unbind(".overlay").width("auto").height("auto") : this.create(a), this.fixed || (f.bind("resize.overlay", c.proxy(this.update, this)), this.update()), a.closeClick && this.overlay.bind("click.overlay", function (a) {
                    if (c(a.target).hasClass("fancybox-overlay")) return h.isActive ? h.close() : b.close(), !1
                }), this.overlay.css(a.css).show()
            },
            close: function () {
                f.unbind("resize.overlay"), this.el.hasClass("fancybox-lock") && (c(".fancybox-margin").removeClass("fancybox-margin"), this.el.removeClass("fancybox-lock"), f.scrollTop(this.scrollV).scrollLeft(this.scrollH)), c(".fancybox-overlay").remove().hide(), c.extend(this, {
                    overlay: null,
                    fixed: !1
                })
            },
            update: function () {
                var c, a = "100%";
                this.overlay.width(a).height("100%"), i ? (c = Math.max(b.documentElement.offsetWidth, b.body.offsetWidth), g.width() > c && (a = g.width())) : g.width() > f.width() && (a = g.width()), this.overlay.width(a).height(g.height())
            },
            onReady: function (a, b) {
                var d = this.overlay;
                c(".fancybox-overlay").stop(!0, !0), d || this.create(a), a.locked && this.fixed && b.fixed && (b.locked = this.overlay.append(b.wrap), b.fixed = !1), a.showEarly === !0 && this.beforeShow.apply(this, arguments)
            },
            beforeShow: function (a, b) {
                b.locked && !this.el.hasClass("fancybox-lock") && (this.fixPosition !== !1 && c("*").filter(function () {
                    return "fixed" === c(this).css("position") && !c(this).hasClass("fancybox-overlay") && !c(this).hasClass("fancybox-wrap")
                }).addClass("fancybox-margin"), this.el.addClass("fancybox-margin"), this.scrollV = f.scrollTop(), this.scrollH = f.scrollLeft(), this.el.addClass("fancybox-lock"), f.scrollTop(this.scrollV).scrollLeft(this.scrollH)), this.open(a)
            },
            onUpdate: function () {
                this.fixed || this.update()
            },
            afterClose: function (a) {
                this.overlay && !h.coming && this.overlay.fadeOut(a.speedOut, c.proxy(this.close, this))
            }
        }, h.helpers.title = {
            defaults: {
                type: "float",
                position: "bottom"
            },
            beforeShow: function (a) {
                var f, g, b = h.current,
                    d = b.title,
                    e = a.type;
                if (c.isFunction(d) && (d = d.call(b.element, b)), m(d) && "" !== c.trim(d)) {
                    switch (f = c('<div class="fancybox-title fancybox-title-' + e + '-wrap">' + d + "</div>"), e) {
                        case "inside":
                            g = h.skin;
                            break;
                        case "outside":
                            g = h.wrap;
                            break;
                        case "over":
                            g = h.inner;
                            break;
                        default:
                            g = h.skin, f.appendTo("body"), i && f.width(f.width()), f.wrapInner('<span class="child"></span>'), h.current.margin[2] += Math.abs(p(f.css("margin-bottom")))
                    }
                    f["top" === a.position ? "prependTo" : "appendTo"](g)
                }
            }
        }, c.fn.fancybox = function (a) {
            var b, d = c(this),
                e = this.selector || "",
                f = function (f) {
                    var j, k, g = c(this).blur(),
                        i = b;
                    f.ctrlKey || f.altKey || f.shiftKey || f.metaKey || g.is(".fancybox-wrap") || (j = a.groupAttr || "data-fancybox-group", k = g.attr(j), k || (j = "rel", k = g.get(0)[j]), k && "" !== k && "nofollow" !== k && (g = e.length ? c(e) : d, g = g.filter("[" + j + '="' + k + '"]'), i = g.index(this)), a.index = i, h.open(g, a) !== !1 && f.preventDefault())
                };
            return a = a || {}, b = a.index || 0, e && a.live !== !1 ? g.undelegate(e, "click.fb-start").delegate(e + ":not('.fancybox-item, .fancybox-nav')", "click.fb-start", f) : d.unbind("click.fb-start").bind("click.fb-start", f), this.filter("[data-fancybox-start=1]").trigger("click"), this
        }, g.ready(function () {
            var b, f;
            c.scrollbarWidth === d && (c.scrollbarWidth = function () {
                var a = c('<div style="width:50px;height:50px;overflow:auto"><div/></div>').appendTo("body"),
                    b = a.children(),
                    d = b.innerWidth() - b.height(99).innerWidth();
                return a.remove(), d
            }), c.support.fixedPosition === d && (c.support.fixedPosition = function () {
                var a = c('<div style="position:fixed;top:20px;"></div>').appendTo("body"),
                    b = 20 === a[0].offsetTop || 15 === a[0].offsetTop;
                return a.remove(), b
            }()), c.extend(h.defaults, {
                scrollbarWidth: c.scrollbarWidth(),
                fixed: c.support.fixedPosition,
                parent: c("body")
            }), b = c(a).width(), e.addClass("fancybox-lock-test"), f = c(a).width(), e.removeClass("fancybox-lock-test"), c("<style type='text/css'>.fancybox-margin{margin-right:" + (f - b) + "px;}</style>").appendTo("head")
        })
    }(window, document, jQuery),
    function () {
        var a;
        a = jQuery, a.fn.extend({
            eqHeight: function (b) {
                return this.each(function () {
                    var c, d, e;
                    if (c = a(this).find(b), 0 === c.length && (c = a(this).children(b)), 0 !== c.length) return e = function () {
                        var b, c;
                        return b = a(".eqHeight_row"), c = 0, b.each(function () {
                            if (a(this).height() > c) return c = a(this).height()
                        }), b.height(c), a(".eqHeight_row").removeClass("eqHeight_row")
                    }, d = function () {
                        var b;
                        return c.height("auto"), b = c.first().position().top, c.each(function () {
                            var c;
                            return c = a(this).position().top, c !== b && (e(), b = a(this).position().top), a(this).addClass("eqHeight_row")
                        }), e()
                    }, a(window).load(d), a(window).resize(d)
                })
            }
        })
    }.call(this),
    function (a, b) {
        "function" == typeof define && define.amd ? define(b) : "object" == typeof exports ? module.exports = b(require, exports, module) : a.CountUp = b()
    }(this, function (a, b, c) {
        var d = function (a, b, c, d, e, f) {
            for (var g = 0, h = ["webkit", "moz", "ms", "o"], i = 0; i < h.length && !window.requestAnimationFrame; ++i) window.requestAnimationFrame = window[h[i] + "RequestAnimationFrame"], window.cancelAnimationFrame = window[h[i] + "CancelAnimationFrame"] || window[h[i] + "CancelRequestAnimationFrame"];
            window.requestAnimationFrame || (window.requestAnimationFrame = function (a, b) {
                var c = (new Date).getTime(),
                    d = Math.max(0, 16 - (c - g)),
                    e = window.setTimeout(function () {
                        a(c + d)
                    }, d);
                return g = c + d, e
            }), window.cancelAnimationFrame || (window.cancelAnimationFrame = function (a) {
                clearTimeout(a)
            }), this.options = {
                useEasing: !0,
                useGrouping: !0,
                separator: ",",
                decimal: "."
            };
            for (var j in f) f.hasOwnProperty(j) && (this.options[j] = f[j]);
            "" === this.options.separator && (this.options.useGrouping = !1), this.options.prefix || (this.options.prefix = ""), this.options.suffix || (this.options.suffix = ""), this.d = "string" == typeof a ? document.getElementById(a) : a, this.startVal = Number(b), this.endVal = Number(c), this.countDown = this.startVal > this.endVal, this.frameVal = this.startVal, this.decimals = Math.max(0, d || 0), this.dec = Math.pow(10, this.decimals), this.duration = 1e3 * Number(e) || 2e3;
            var k = this;
            this.version = function () {
                return "1.6.0"
            }, this.printValue = function (a) {
                var b = isNaN(a) ? "--" : k.formatNumber(a);
                "INPUT" == k.d.tagName ? this.d.value = b : "text" == k.d.tagName || "tspan" == k.d.tagName ? this.d.textContent = b : this.d.innerHTML = b
            }, this.easeOutExpo = function (a, b, c, d) {
                return c * (-Math.pow(2, -10 * a / d) + 1) * 1024 / 1023 + b
            }, this.count = function (a) {
                k.startTime || (k.startTime = a), k.timestamp = a;
                var b = a - k.startTime;
                k.remaining = k.duration - b, k.options.useEasing ? k.countDown ? k.frameVal = k.startVal - k.easeOutExpo(b, 0, k.startVal - k.endVal, k.duration) : k.frameVal = k.easeOutExpo(b, k.startVal, k.endVal - k.startVal, k.duration) : k.countDown ? k.frameVal = k.startVal - (k.startVal - k.endVal) * (b / k.duration) : k.frameVal = k.startVal + (k.endVal - k.startVal) * (b / k.duration), k.countDown ? k.frameVal = k.frameVal < k.endVal ? k.endVal : k.frameVal : k.frameVal = k.frameVal > k.endVal ? k.endVal : k.frameVal, k.frameVal = Math.round(k.frameVal * k.dec) / k.dec, k.printValue(k.frameVal), b < k.duration ? k.rAF = requestAnimationFrame(k.count) : k.callback && k.callback()
            }, this.start = function (a) {
                return k.callback = a, k.rAF = requestAnimationFrame(k.count), !1
            }, this.pauseResume = function () {
                k.paused ? (k.paused = !1, delete k.startTime, k.duration = k.remaining, k.startVal = k.frameVal, requestAnimationFrame(k.count)) : (k.paused = !0, cancelAnimationFrame(k.rAF))
            }, this.reset = function () {
                k.paused = !1, delete k.startTime, k.startVal = b, cancelAnimationFrame(k.rAF), k.printValue(k.startVal)
            }, this.update = function (a) {
                cancelAnimationFrame(k.rAF), k.paused = !1, delete k.startTime, k.startVal = k.frameVal, k.endVal = Number(a), k.countDown = k.startVal > k.endVal, k.rAF = requestAnimationFrame(k.count)
            }, this.formatNumber = function (a) {
                a = a.toFixed(k.decimals), a += "";
                var b, c, d, e;
                if (b = a.split("."), c = b[0], d = b.length > 1 ? k.options.decimal + b[1] : "", e = /(\d+)(\d{3})/, k.options.useGrouping)
                    for (; e.test(c);) c = c.replace(e, "$1" + k.options.separator + "$2");
                return k.options.prefix + c + d + k.options.suffix
            }, k.printValue(k.startVal)
        };
        return d
    }),
    function () {
        "use strict";

        function c(d) {
            if (!d) throw new Error("No options passed to Waypoint constructor");
            if (!d.element) throw new Error("No element option passed to Waypoint constructor");
            if (!d.handler) throw new Error("No handler option passed to Waypoint constructor");
            this.key = "waypoint-" + a, this.options = c.Adapter.extend({}, c.defaults, d), this.element = this.options.element, this.adapter = new c.Adapter(this.element), this.callback = d.handler, this.axis = this.options.horizontal ? "horizontal" : "vertical", this.enabled = this.options.enabled, this.triggerPoint = null, this.group = c.Group.findOrCreate({
                name: this.options.group,
                axis: this.axis
            }), this.context = c.Context.findOrCreateByElement(this.options.context), c.offsetAliases[this.options.offset] && (this.options.offset = c.offsetAliases[this.options.offset]), this.group.add(this), this.context.add(this), b[this.key] = this, a += 1
        }
        var a = 0,
            b = {};
        c.prototype.queueTrigger = function (a) {
            this.group.queueTrigger(this, a)
        }, c.prototype.trigger = function (a) {
            this.enabled && this.callback && this.callback.apply(this, a)
        }, c.prototype.destroy = function () {
            this.context.remove(this), this.group.remove(this), delete b[this.key]
        }, c.prototype.disable = function () {
            return this.enabled = !1, this
        }, c.prototype.enable = function () {
            return this.context.refresh(), this.enabled = !0, this
        }, c.prototype.next = function () {
            return this.group.next(this)
        }, c.prototype.previous = function () {
            return this.group.previous(this)
        }, c.invokeAll = function (a) {
            var c = [];
            for (var d in b) c.push(b[d]);
            for (var e = 0, f = c.length; e < f; e++) c[e][a]()
        }, c.destroyAll = function () {
            c.invokeAll("destroy")
        }, c.disableAll = function () {
            c.invokeAll("disable")
        }, c.enableAll = function () {
            c.invokeAll("enable")
        }, c.refreshAll = function () {
            c.Context.refreshAll()
        }, c.viewportHeight = function () {
            return window.innerHeight || document.documentElement.clientHeight
        }, c.viewportWidth = function () {
            return document.documentElement.clientWidth
        }, c.adapters = [], c.defaults = {
            context: window,
            continuous: !0,
            enabled: !0,
            group: "default",
            horizontal: !1,
            offset: 0
        }, c.offsetAliases = {
            "bottom-in-view": function () {
                return this.context.innerHeight() - this.adapter.outerHeight()
            },
            "right-in-view": function () {
                return this.context.innerWidth() - this.adapter.outerWidth()
            }
        }, window.Waypoint = c
    }(),
    function () {
        "use strict";

        function a(a) {
            window.setTimeout(a, 1e3 / 60)
        }

        function f(a) {
            this.element = a, this.Adapter = d.Adapter, this.adapter = new this.Adapter(a), this.key = "waypoint-context-" + b, this.didScroll = !1, this.didResize = !1, this.oldScroll = {
                x: this.adapter.scrollLeft(),
                y: this.adapter.scrollTop()
            }, this.waypoints = {
                vertical: {},
                horizontal: {}
            }, a.waypointContextKey = this.key, c[a.waypointContextKey] = this, b += 1, this.createThrottledScrollHandler(), this.createThrottledResizeHandler()
        }
        var b = 0,
            c = {},
            d = window.Waypoint,
            e = window.onload;
        f.prototype.add = function (a) {
            var b = a.options.horizontal ? "horizontal" : "vertical";
            this.waypoints[b][a.key] = a, this.refresh()
        }, f.prototype.checkEmpty = function () {
            var a = this.Adapter.isEmptyObject(this.waypoints.horizontal),
                b = this.Adapter.isEmptyObject(this.waypoints.vertical);
            a && b && (this.adapter.off(".waypoints"), delete c[this.key])
        }, f.prototype.createThrottledResizeHandler = function () {
            function b() {
                a.handleResize(), a.didResize = !1
            }
            var a = this;
            this.adapter.on("resize.waypoints", function () {
                a.didResize || (a.didResize = !0, d.requestAnimationFrame(b))
            })
        }, f.prototype.createThrottledScrollHandler = function () {
            function b() {
                a.handleScroll(), a.didScroll = !1
            }
            var a = this;
            this.adapter.on("scroll.waypoints", function () {
                a.didScroll && !d.isTouch || (a.didScroll = !0, d.requestAnimationFrame(b))
            })
        }, f.prototype.handleResize = function () {
            d.Context.refreshAll()
        }, f.prototype.handleScroll = function () {
            var a = {},
                b = {
                    horizontal: {
                        newScroll: this.adapter.scrollLeft(),
                        oldScroll: this.oldScroll.x,
                        forward: "right",
                        backward: "left"
                    },
                    vertical: {
                        newScroll: this.adapter.scrollTop(),
                        oldScroll: this.oldScroll.y,
                        forward: "down",
                        backward: "up"
                    }
                };
            for (var c in b) {
                var d = b[c],
                    e = d.newScroll > d.oldScroll,
                    f = e ? d.forward : d.backward;
                for (var g in this.waypoints[c]) {
                    var h = this.waypoints[c][g],
                        i = d.oldScroll < h.triggerPoint,
                        j = d.newScroll >= h.triggerPoint,
                        k = i && j,
                        l = !i && !j;
                    (k || l) && (h.queueTrigger(f), a[h.group.id] = h.group)
                }
            }
            for (var m in a) a[m].flushTriggers();
            this.oldScroll = {
                x: b.horizontal.newScroll,
                y: b.vertical.newScroll
            }
        }, f.prototype.innerHeight = function () {
            return this.element == this.element.window ? d.viewportHeight() : this.adapter.innerHeight()
        }, f.prototype.remove = function (a) {
            delete this.waypoints[a.axis][a.key], this.checkEmpty()
        }, f.prototype.innerWidth = function () {
            return this.element == this.element.window ? d.viewportWidth() : this.adapter.innerWidth()
        }, f.prototype.destroy = function () {
            var a = [];
            for (var b in this.waypoints)
                for (var c in this.waypoints[b]) a.push(this.waypoints[b][c]);
            for (var d = 0, e = a.length; d < e; d++) a[d].destroy()
        }, f.prototype.refresh = function () {
            var e, a = this.element == this.element.window,
                b = a ? void 0 : this.adapter.offset(),
                c = {};
            this.handleScroll(), e = {
                horizontal: {
                    contextOffset: a ? 0 : b.left,
                    contextScroll: a ? 0 : this.oldScroll.x,
                    contextDimension: this.innerWidth(),
                    oldScroll: this.oldScroll.x,
                    forward: "right",
                    backward: "left",
                    offsetProp: "left"
                },
                vertical: {
                    contextOffset: a ? 0 : b.top,
                    contextScroll: a ? 0 : this.oldScroll.y,
                    contextDimension: this.innerHeight(),
                    oldScroll: this.oldScroll.y,
                    forward: "down",
                    backward: "up",
                    offsetProp: "top"
                }
            };
            for (var f in e) {
                var g = e[f];
                for (var h in this.waypoints[f]) {
                    var n, o, p, q, r, i = this.waypoints[f][h],
                        j = i.options.offset,
                        k = i.triggerPoint,
                        l = 0,
                        m = null == k;
                    i.element !== i.element.window && (l = i.adapter.offset()[g.offsetProp]), "function" == typeof j ? j = j.apply(i) : "string" == typeof j && (j = parseFloat(j), i.options.offset.indexOf("%") > -1 && (j = Math.ceil(g.contextDimension * j / 100))), n = g.contextScroll - g.contextOffset, i.triggerPoint = l + n - j, o = k < g.oldScroll, p = i.triggerPoint >= g.oldScroll, q = o && p, r = !o && !p, !m && q ? (i.queueTrigger(g.backward), c[i.group.id] = i.group) : !m && r ? (i.queueTrigger(g.forward), c[i.group.id] = i.group) : m && g.oldScroll >= i.triggerPoint && (i.queueTrigger(g.forward), c[i.group.id] = i.group)
                }
            }
            return d.requestAnimationFrame(function () {
                for (var a in c) c[a].flushTriggers()
            }), this
        }, f.findOrCreateByElement = function (a) {
            return f.findByElement(a) || new f(a)
        }, f.refreshAll = function () {
            for (var a in c) c[a].refresh()
        }, f.findByElement = function (a) {
            return c[a.waypointContextKey]
        }, window.onload = function () {
            e && e(), f.refreshAll()
        }, d.requestAnimationFrame = function (b) {
            var c = window.requestAnimationFrame || window.mozRequestAnimationFrame || window.webkitRequestAnimationFrame || a;
            c.call(window, b)
        }, d.Context = f
    }(),
    function () {
        "use strict";

        function a(a, b) {
            return a.triggerPoint - b.triggerPoint
        }

        function b(a, b) {
            return b.triggerPoint - a.triggerPoint
        }

        function e(a) {
            this.name = a.name, this.axis = a.axis, this.id = this.name + "-" + this.axis, this.waypoints = [], this.clearTriggerQueues(), c[this.axis][this.name] = this
        }
        var c = {
            vertical: {},
            horizontal: {}
        },
            d = window.Waypoint;
        e.prototype.add = function (a) {
            this.waypoints.push(a)
        }, e.prototype.clearTriggerQueues = function () {
            this.triggerQueues = {
                up: [],
                down: [],
                left: [],
                right: []
            }
        }, e.prototype.flushTriggers = function () {
            for (var c in this.triggerQueues) {
                var d = this.triggerQueues[c],
                    e = "up" === c || "left" === c;
                d.sort(e ? b : a);
                for (var f = 0, g = d.length; f < g; f += 1) {
                    var h = d[f];
                    (h.options.continuous || f === d.length - 1) && h.trigger([c])
                }
            }
            this.clearTriggerQueues()
        }, e.prototype.next = function (b) {
            this.waypoints.sort(a);
            var c = d.Adapter.inArray(b, this.waypoints),
                e = c === this.waypoints.length - 1;
            return e ? null : this.waypoints[c + 1]
        }, e.prototype.previous = function (b) {
            this.waypoints.sort(a);
            var c = d.Adapter.inArray(b, this.waypoints);
            return c ? this.waypoints[c - 1] : null
        }, e.prototype.queueTrigger = function (a, b) {
            this.triggerQueues[b].push(a)
        }, e.prototype.remove = function (a) {
            var b = d.Adapter.inArray(a, this.waypoints);
            b > -1 && this.waypoints.splice(b, 1)
        }, e.prototype.first = function () {
            return this.waypoints[0]
        }, e.prototype.last = function () {
            return this.waypoints[this.waypoints.length - 1]
        }, e.findOrCreate = function (a) {
            return c[a.axis][a.name] || new e(a)
        }, d.Group = e
    }(),
    function () {
        "use strict";

        function c(b) {
            this.$element = a(b)
        }
        var a = window.jQuery,
            b = window.Waypoint;
        a.each(["innerHeight", "innerWidth", "off", "offset", "on", "outerHeight", "outerWidth", "scrollLeft", "scrollTop"], function (a, b) {
            c.prototype[b] = function () {
                var a = Array.prototype.slice.call(arguments);
                return this.$element[b].apply(this.$element, a)
            }
        }), a.each(["extend", "inArray", "isEmptyObject"], function (b, d) {
            c[d] = a[d]
        }), b.adapters.push({
            name: "jquery",
            Adapter: c
        }), b.Adapter = c
    }(),
    function () {
        "use strict";

        function b(b) {
            return function () {
                var c = [],
                    d = arguments[0];
                return b.isFunction(arguments[0]) && (d = b.extend({}, arguments[1]), d.handler = arguments[0]), this.each(function () {
                    var e = b.extend({}, d, {
                        element: this
                    });
                    "string" == typeof e.context && (e.context = b(this).closest(e.context)[0]), c.push(new a(e))
                }), c
            }
        }
        var a = window.Waypoint;
        window.jQuery && (window.jQuery.fn.waypoint = b(window.jQuery)), window.Zepto && (window.Zepto.fn.waypoint = b(window.Zepto))
    }(),
    function (a, b, c) {
        "use strict";
        var d = {
            filterId: 0
        },
            e = c("body"),
            f = function (f, g) {
                var p, q, r, h = {
                    intensity: 5,
                    forceSVGUrl: !1,
                    animationOptions: {
                        duration: 1e3,
                        easing: "linear"
                    }
                },
                    i = c.extend(h, g),
                    j = " -webkit- -moz- -o- -ms- ".split(" "),
                    k = {},
                    l = function (a) {
                        if (k[a] || "" === k[a]) return k[a] + a;
                        var c = b.createElement("div"),
                            d = ["", "Moz", "Webkit", "O", "ms", "Khtml"];
                        for (var e in d)
                            if ("undefined" != typeof c.style[d[e] + a]) return k[a] = d[e], d[e] + a;
                        return a.toLowerCase()
                    },
                    m = {
                        cssfilters: function () {
                            var a = b.createElement("div");
                            return a.style.cssText = j.join("filter:blur(2px); "), !!a.style.length && (void 0 === b.documentMode || b.documentMode > 9)
                        }(),
                        svgfilters: function () {
                            var a = !1;
                            try {
                                a = void 0 !== typeof SVGFEColorMatrixElement && 2 == SVGFEColorMatrixElement.SVG_FECOLORMATRIX_TYPE_SATURATE
                            } catch (a) { }
                            return a
                        }()
                    },
                    n = !1,
                    o = l("Filter"),
                    s = function (a) {
                        return b.createElementNS("http://www.w3.org/2000/svg", a)
                    },
                    t = function () {
                        var a = s("svg"),
                            b = s("filter");
                        p = s("feGaussianBlur"), a.setAttribute("style", "position:absolute"), a.setAttribute("width", "0"), a.setAttribute("height", "0"), b.setAttribute("id", "blur-effect-id-" + d.filterId), b.appendChild(p), a.appendChild(b), e.append(a)
                    };
                return this.$elm = f instanceof c ? f : c(f), this.init = function () {
                    return m.svgfilters && t(), q = d.filterId, d.filterId++ , this
                }, this.blur = function () {
                    var b, c = a.location,
                        d = i.forceSVGUrl ? c.protocol + "//" + c.host + c.pathname + c.search : "";
                    return m.cssfilters ? b = "blur(" + i.intensity + "px)" : m.svgfilters ? (p.setAttribute("stdDeviation", i.intensity), b = "url(" + d + "#blur-effect-id-" + q + ")") : b = "progid:DXImageTransform.Microsoft.Blur(pixelradius=" + i.intensity + ")", this.$elm[0].style[o] = b, n = !0, this
                }, this.animate = function (a, b) {
                    if ("number" != typeof a) throw typeof a + " is not a valid number to animate the blur";
                    if (a < 0) throw "I can animate only positive numbers";
                    var d = new c.Deferred;
                    return r && r.stop(!0, !0), r = new c.Animation(i, {
                        intensity: a
                    }, c.extend(i.animationOptions, b)).progress(c.proxy(this.blur, this)).done(d.resolve), d.promise()
                }, this.unblur = function () {
                    return this.$elm.css(o, "none"), n = !1, this
                }, this.toggleblur = function () {
                    return n ? this.unblur() : this.blur(), this
                }, this.destroy = function () {
                    m.svgfilters && c("filter#blur-effect-id-" + q).parent().remove(), this.unblur();
                    for (var a in this) delete this[a];
                    return this
                }, this.init()
            };
        c.fn.Vague = function (a) {
            return new f(this, a)
        }
    }(window, document, jQuery);
var requirejs, require, define;
! function (global) {
    function isFunction(a) {
        return "[object Function]" === ostring.call(a)
    }

    function isArray(a) {
        return "[object Array]" === ostring.call(a)
    }

    function each(a, b) {
        if (a) {
            var c;
            for (c = 0; c < a.length && (!a[c] || !b(a[c], c, a)); c += 1);
        }
    }

    function eachReverse(a, b) {
        if (a) {
            var c;
            for (c = a.length - 1; c > -1 && (!a[c] || !b(a[c], c, a)); c -= 1);
        }
    }

    function hasProp(a, b) {
        return hasOwn.call(a, b)
    }

    function getOwn(a, b) {
        return hasProp(a, b) && a[b]
    }

    function eachProp(a, b) {
        var c;
        for (c in a)
            if (hasProp(a, c) && b(a[c], c)) break
    }

    function mixin(a, b, c, d) {
        return b && eachProp(b, function (b, e) {
            !c && hasProp(a, e) || (!d || "object" != typeof b || !b || isArray(b) || isFunction(b) || b instanceof RegExp ? a[e] = b : (a[e] || (a[e] = {}), mixin(a[e], b, c, d)))
        }), a
    }

    function bind(a, b) {
        return function () {
            return b.apply(a, arguments)
        }
    }

    function scripts() {
        return document.getElementsByTagName("script")
    }

    function defaultOnError(a) {
        return; //hotfix
        throw a
    }

    function getGlobal(a) {
        if (!a) return a;
        var b = global;
        return each(a.split("."), function (a) {
            b = b[a]
        }), b
    }

    function makeError(a, b, c, d) {
        var e = new Error(b + "\nhttp://requirejs.org/docs/errors.html#" + a);
        return e.requireType = a, e.requireModules = d, c && (e.originalError = c), e
    }

    function newContext(a) {
        function q(a) {
            var b, c;
            for (b = 0; b < a.length; b++)
                if (c = a[b], "." === c) a.splice(b, 1), b -= 1;
                else if (".." === c) {
                    if (0 === b || 1 === b && ".." === a[2] || ".." === a[b - 1]) continue;
                    b > 0 && (a.splice(b - 1, 2), b -= 2)
                }
        }

        function r(a, b, c) {
            var d, e, f, h, i, j, k, l, m, n, o, p, r = b && b.split("/"),
                s = g.map,
                t = s && s["*"];
            if (a && (a = a.split("/"), k = a.length - 1, g.nodeIdCompat && jsSuffixRegExp.test(a[k]) && (a[k] = a[k].replace(jsSuffixRegExp, "")), "." === a[0].charAt(0) && r && (p = r.slice(0, r.length - 1), a = p.concat(a)), q(a), a = a.join("/")), c && s && (r || t)) {
                f = a.split("/");
                a: for (h = f.length; h > 0; h -= 1) {
                    if (j = f.slice(0, h).join("/"), r)
                        for (i = r.length; i > 0; i -= 1)
                            if (e = getOwn(s, r.slice(0, i).join("/")), e && (e = getOwn(e, j))) {
                                l = e, m = h;
                                break a
                            } !n && t && getOwn(t, j) && (n = getOwn(t, j), o = h)
                } !l && n && (l = n, m = o), l && (f.splice(0, m, l), a = f.join("/"))
            }
            return d = getOwn(g.pkgs, a), d ? d : a
        }

        function s(a) {
            isBrowser && each(scripts(), function (b) {
                if (b.getAttribute("data-requiremodule") === a && b.getAttribute("data-requirecontext") === d.contextName) return b.parentNode.removeChild(b), !0
            })
        }

        function t(a) {
            var b = getOwn(g.paths, a);
            if (b && isArray(b) && b.length > 1) return b.shift(), d.require.undef(a), d.makeRequire(null, {
                skipMap: !0
            })([a]), !0
        }

        function u(a) {
            var b, c = a ? a.indexOf("!") : -1;
            return c > -1 && (b = a.substring(0, c), a = a.substring(c + 1, a.length)), [b, a]
        }

        function v(a, b, c, e) {
            var f, g, h, i, j = null,
                k = b ? b.name : null,
                m = a,
                n = !0,
                q = "";
            return a || (n = !1, a = "_@r" + (o += 1)), i = u(a), j = i[0], a = i[1], j && (j = r(j, k, e), g = getOwn(l, j)), a && (j ? q = g && g.normalize ? g.normalize(a, function (a) {
                return r(a, k, e)
            }) : a.indexOf("!") === -1 ? r(a, k, e) : a : (q = r(a, k, e), i = u(q), j = i[0], q = i[1], c = !0, f = d.nameToUrl(q))), h = !j || g || c ? "" : "_unnormalized" + (p += 1), {
                    prefix: j,
                    name: q,
                    parentMap: b,
                    unnormalized: !!h,
                    url: f,
                    originalName: m,
                    isDefine: n,
                    id: (j ? j + "!" + q : q) + h
                }
        }

        function w(a) {
            var b = a.id,
                c = getOwn(h, b);
            return c || (c = h[b] = new d.Module(a)), c
        }

        function x(a, b, c) {
            var d = a.id,
                e = getOwn(h, d);
            !hasProp(l, d) || e && !e.defineEmitComplete ? (e = w(a), e.error && "error" === b ? c(e.error) : e.on(b, c)) : "defined" === b && c(l[d])
        }

        function y(a, b) {
            var c = a.requireModules,
                d = !1;
            b ? b(a) : (each(c, function (b) {
                var c = getOwn(h, b);
                c && (c.error = a, c.events.error && (d = !0, c.emit("error", a)))
            }), d || req.onError(a))
        }

        function z() {
            globalDefQueue.length && (each(globalDefQueue, function (a) {
                var b = a[0];
                "string" == typeof b && (d.defQueueMap[b] = !0), k.push(a)
            }), globalDefQueue = [])
        }

        function A(a) {
            delete h[a], delete i[a]
        }

        function B(a, b, c) {
            var d = a.map.id;
            a.error ? a.emit("error", a.error) : (b[d] = !0, each(a.depMaps, function (d, e) {
                var f = d.id,
                    g = getOwn(h, f);
                !g || a.depMatched[e] || c[f] || (getOwn(b, f) ? (a.defineDep(e, l[f]), a.check()) : B(g, b, c))
            }), c[d] = !0)
        }

        function C() {
            var a, c, e = 1e3 * g.waitSeconds,
                h = e && d.startTime + e < (new Date).getTime(),
                j = [],
                k = [],
                l = !1,
                m = !0;
            if (!b) {
                if (b = !0, eachProp(i, function (a) {
                    var b = a.map,
                        d = b.id;
                    if (a.enabled && (b.isDefine || k.push(a), !a.error))
                        if (!a.inited && h) t(d) ? (c = !0, l = !0) : (j.push(d), s(d));
                        else if (!a.inited && a.fetched && b.isDefine && (l = !0, !b.prefix)) return m = !1
                }), h && j.length) return a = makeError("timeout", "Load timeout for modules: " + j, null, j), a.contextName = d.contextName, y(a);
                m && each(k, function (a) {
                    B(a, {}, {})
                }), h && !c || !l || !isBrowser && !isWebWorker || f || (f = setTimeout(function () {
                    f = 0, C()
                }, 50)), b = !1
            }
        }

        function D(a) {
            hasProp(l, a[0]) || w(v(a[0], null, !0)).init(a[1], a[2])
        }

        function E(a, b, c, d) {
            a.detachEvent && !isOpera ? d && a.detachEvent(d, b) : a.removeEventListener(c, b, !1)
        }

        function F(a) {
            var b = a.currentTarget || a.srcElement;
            return E(b, d.onScriptLoad, "load", "onreadystatechange"), E(b, d.onScriptError, "error"), {
                node: b,
                id: b && b.getAttribute("data-requiremodule")
            }
        }

        function G() {
            var a;
            for (z(); k.length;) {
                if (a = k.shift(), null === a[0]) return y(makeError("mismatch", "Mismatched anonymous define() module: " + a[a.length - 1]));
                D(a)
            }
            d.defQueueMap = {}
        }
        var b, c, d, e, f, g = {
            waitSeconds: 7,
            baseUrl: "./",
            paths: {},
            bundles: {},
            pkgs: {},
            shim: {},
            config: {}
        },
            h = {},
            i = {},
            j = {},
            k = [],
            l = {},
            m = {},
            n = {},
            o = 1,
            p = 1;
        return e = {
            require: function (a) {
                return a.require ? a.require : a.require = d.makeRequire(a.map)
            },
            exports: function (a) {
                if (a.usingExports = !0, a.map.isDefine) return a.exports ? l[a.map.id] = a.exports : a.exports = l[a.map.id] = {}
            },
            module: function (a) {
                return a.module ? a.module : a.module = {
                    id: a.map.id,
                    uri: a.map.url,
                    config: function () {
                        return getOwn(g.config, a.map.id) || {}
                    },
                    exports: a.exports || (a.exports = {})
                }
            }
        }, c = function (a) {
            this.events = getOwn(j, a.id) || {}, this.map = a, this.shim = getOwn(g.shim, a.id), this.depExports = [], this.depMaps = [], this.depMatched = [], this.pluginMaps = {}, this.depCount = 0
        }, c.prototype = {
            init: function (a, b, c, d) {
                d = d || {}, this.inited || (this.factory = b, c ? this.on("error", c) : this.events.error && (c = bind(this, function (a) {
                    this.emit("error", a)
                })), this.depMaps = a && a.slice(0), this.errback = c, this.inited = !0, this.ignore = d.ignore, d.enabled || this.enabled ? this.enable() : this.check())
            },
            defineDep: function (a, b) {
                this.depMatched[a] || (this.depMatched[a] = !0, this.depCount -= 1, this.depExports[a] = b)
            },
            fetch: function () {
                if (!this.fetched) {
                    this.fetched = !0, d.startTime = (new Date).getTime();
                    var a = this.map;
                    return this.shim ? void d.makeRequire(this.map, {
                        enableBuildCallback: !0
                    })(this.shim.deps || [], bind(this, function () {
                        return a.prefix ? this.callPlugin() : this.load()
                    })) : a.prefix ? this.callPlugin() : this.load()
                }
            },
            load: function () {
                var a = this.map.url;
                m[a] || (m[a] = !0, d.load(this.map.id, a))
            },
            check: function () {
                if (this.enabled && !this.enabling) {
                    var a, b, c = this.map.id,
                        e = this.depExports,
                        f = this.exports,
                        g = this.factory;
                    if (this.inited) {
                        if (this.error) this.emit("error", this.error);
                        else if (!this.defining) {
                            if (this.defining = !0, this.depCount < 1 && !this.defined) {
                                if (isFunction(g)) {
                                    try {
                                        f = d.execCb(c, g, e, f)
                                    } catch (b) {
                                        a = b
                                    }
                                    if (this.map.isDefine && void 0 === f && (b = this.module, b ? f = b.exports : this.usingExports && (f = this.exports)), a) {
                                        if (this.events.error && this.map.isDefine || req.onError !== defaultOnError) return a.requireMap = this.map, a.requireModules = this.map.isDefine ? [this.map.id] : null, a.requireType = this.map.isDefine ? "define" : "require", y(this.error = a);
                                        "undefined" != typeof console && console.error ? console.error(a) : req.onError(a)
                                    }
                                } else f = g;
                                if (this.exports = f, this.map.isDefine && !this.ignore && (l[c] = f, req.onResourceLoad)) {
                                    var h = [];
                                    each(this.depMaps, function (a) {
                                        h.push(a.normalizedMap || a)
                                    }), req.onResourceLoad(d, this.map, h)
                                }
                                A(c), this.defined = !0
                            }
                            this.defining = !1, this.defined && !this.defineEmitted && (this.defineEmitted = !0, this.emit("defined", this.exports), this.defineEmitComplete = !0)
                        }
                    } else hasProp(d.defQueueMap, c) || this.fetch()
                }
            },
            callPlugin: function () {
                var a = this.map,
                    b = a.id,
                    c = v(a.prefix);
                this.depMaps.push(c), x(c, "defined", bind(this, function (c) {
                    var e, f, i, j = getOwn(n, this.map.id),
                        k = this.map.name,
                        l = this.map.parentMap ? this.map.parentMap.name : null,
                        m = d.makeRequire(a.parentMap, {
                            enableBuildCallback: !0
                        });
                    return this.map.unnormalized ? (c.normalize && (k = c.normalize(k, function (a) {
                        return r(a, l, !0)
                    }) || ""), f = v(a.prefix + "!" + k, this.map.parentMap), x(f, "defined", bind(this, function (a) {
                        this.map.normalizedMap = f, this.init([], function () {
                            return a
                        }, null, {
                                enabled: !0,
                                ignore: !0
                            })
                    })), i = getOwn(h, f.id), void (i && (this.depMaps.push(f), this.events.error && i.on("error", bind(this, function (a) {
                        this.emit("error", a)
                    })), i.enable()))) : j ? (this.map.url = d.nameToUrl(j), void this.load()) : (e = bind(this, function (a) {
                        this.init([], function () {
                            return a
                        }, null, {
                                enabled: !0
                            })
                    }), e.error = bind(this, function (a) {
                        this.inited = !0, this.error = a, a.requireModules = [b], eachProp(h, function (a) {
                            0 === a.map.id.indexOf(b + "_unnormalized") && A(a.map.id)
                        }), y(a)
                    }), e.fromText = bind(this, function (c, f) {
                        var h = a.name,
                            i = v(h),
                            j = useInteractive;
                        f && (c = f), j && (useInteractive = !1), w(i), hasProp(g.config, b) && (g.config[h] = g.config[b]);
                        try {
                            req.exec(c)
                        } catch (a) {
                            return y(makeError("fromtexteval", "fromText eval for " + b + " failed: " + a, a, [b]))
                        }
                        j && (useInteractive = !0), this.depMaps.push(i), d.completeLoad(h), m([h], e)
                    }), void c.load(a.name, m, e, g))
                })), d.enable(c, this), this.pluginMaps[c.id] = c
            },
            enable: function () {
                i[this.map.id] = this, this.enabled = !0, this.enabling = !0, each(this.depMaps, bind(this, function (a, b) {
                    var c, f, g;
                    if ("string" == typeof a) {
                        if (a = v(a, this.map.isDefine ? this.map : this.map.parentMap, !1, !this.skipMap), this.depMaps[b] = a, g = getOwn(e, a.id)) return void (this.depExports[b] = g(this));
                        this.depCount += 1, x(a, "defined", bind(this, function (a) {
                            this.undefed || (this.defineDep(b, a), this.check())
                        })), this.errback ? x(a, "error", bind(this, this.errback)) : this.events.error && x(a, "error", bind(this, function (a) {
                            this.emit("error", a)
                        }))
                    }
                    c = a.id, f = h[c], hasProp(e, c) || !f || f.enabled || d.enable(a, this)
                })), eachProp(this.pluginMaps, bind(this, function (a) {
                    var b = getOwn(h, a.id);
                    b && !b.enabled && d.enable(a, this)
                })), this.enabling = !1, this.check()
            },
            on: function (a, b) {
                var c = this.events[a];
                c || (c = this.events[a] = []), c.push(b)
            },
            emit: function (a, b) {
                each(this.events[a], function (a) {
                    a(b)
                }), "error" === a && delete this.events[a]
            }
        }, d = {
            config: g,
            contextName: a,
            registry: h,
            defined: l,
            urlFetched: m,
            defQueue: k,
            defQueueMap: {},
            Module: c,
            makeModuleMap: v,
            nextTick: req.nextTick,
            onError: y,
            configure: function (a) {
                a.baseUrl && "/" !== a.baseUrl.charAt(a.baseUrl.length - 1) && (a.baseUrl += "/");
                var b = g.shim,
                    c = {
                        paths: !0,
                        bundles: !0,
                        config: !0,
                        map: !0
                    };
                eachProp(a, function (a, b) {
                    c[b] ? (g[b] || (g[b] = {}), mixin(g[b], a, !0, !0)) : g[b] = a
                }), a.bundles && eachProp(a.bundles, function (a, b) {
                    each(a, function (a) {
                        a !== b && (n[a] = b)
                    })
                }), a.shim && (eachProp(a.shim, function (a, c) {
                    isArray(a) && (a = {
                        deps: a
                    }), !a.exports && !a.init || a.exportsFn || (a.exportsFn = d.makeShimExports(a)), b[c] = a
                }), g.shim = b), a.packages && each(a.packages, function (a) {
                    var b, c;
                    a = "string" == typeof a ? {
                        name: a
                    } : a, c = a.name, b = a.location, b && (g.paths[c] = a.location), g.pkgs[c] = a.name + "/" + (a.main || "main").replace(currDirRegExp, "").replace(jsSuffixRegExp, "")
                }), eachProp(h, function (a, b) {
                    a.inited || a.map.unnormalized || (a.map = v(b, null, !0))
                }), (a.deps || a.callback) && d.require(a.deps || [], a.callback)
            },
            makeShimExports: function (a) {
                function b() {
                    var b;
                    return a.init && (b = a.init.apply(global, arguments)), b || a.exports && getGlobal(a.exports)
                }
                return b
            },
            makeRequire: function (b, c) {
                function f(g, i, j) {
                    var k, m, n;
                    return c.enableBuildCallback && i && isFunction(i) && (i.__requireJsBuild = !0), "string" == typeof g ? isFunction(i) ? y(makeError("requireargs", "Invalid require call"), j) : b && hasProp(e, g) ? e[g](h[b.id]) : req.get ? req.get(d, g, b, f) : (m = v(g, b, !1, !0), k = m.id, hasProp(l, k) ? l[k] : y(makeError("notloaded", 'Module name "' + k + '" has not been loaded yet for context: ' + a + (b ? "" : ". Use require([])")))) : (G(), d.nextTick(function () {
                        G(), n = w(v(null, b)), n.skipMap = c.skipMap, n.init(g, i, j, {
                            enabled: !0
                        }), C()
                    }), f)
                }
                return c = c || {}, mixin(f, {
                    isBrowser: isBrowser,
                    toUrl: function (a) {
                        var c, e = a.lastIndexOf("."),
                            f = a.split("/")[0],
                            g = "." === f || ".." === f;
                        return e !== -1 && (!g || e > 1) && (c = a.substring(e, a.length), a = a.substring(0, e)), d.nameToUrl(r(a, b && b.id, !0), c, !0)
                    },
                    defined: function (a) {
                        return hasProp(l, v(a, b, !1, !0).id)
                    },
                    specified: function (a) {
                        return a = v(a, b, !1, !0).id, hasProp(l, a) || hasProp(h, a)
                    }
                }), b || (f.undef = function (a) {
                    z();
                    var c = v(a, b, !0),
                        e = getOwn(h, a);
                    e.undefed = !0, s(a), delete l[a], delete m[c.url], delete j[a], eachReverse(k, function (b, c) {
                        b[0] === a && k.splice(c, 1)
                    }), delete d.defQueueMap[a], e && (e.events.defined && (j[a] = e.events), A(a))
                }), f
            },
            enable: function (a) {
                var b = getOwn(h, a.id);
                b && w(a).enable()
            },
            completeLoad: function (a) {
                var b, c, e, f = getOwn(g.shim, a) || {},
                    i = f.exports;
                for (z(); k.length;) {
                    if (c = k.shift(), null === c[0]) {
                        if (c[0] = a, b) break;
                        b = !0
                    } else c[0] === a && (b = !0);
                    D(c)
                }
                if (d.defQueueMap = {}, e = getOwn(h, a), !b && !hasProp(l, a) && e && !e.inited) {
                    if (!(!g.enforceDefine || i && getGlobal(i))) return t(a) ? void 0 : y(makeError("nodefine", "No define call for " + a, null, [a]));
                    D([a, f.deps || [], f.exportsFn])
                }
                C()
            },
            nameToUrl: function (a, b, c) {
                var e, f, h, i, j, k, l, m = getOwn(g.pkgs, a);
                if (m && (a = m), l = getOwn(n, a)) return d.nameToUrl(l, b, c);
                if (req.jsExtRegExp.test(a)) j = a + (b || "");
                else {
                    for (e = g.paths, f = a.split("/"), h = f.length; h > 0; h -= 1)
                        if (i = f.slice(0, h).join("/"), k = getOwn(e, i)) {
                            isArray(k) && (k = k[0]), f.splice(0, h, k);
                            break
                        }
                    j = f.join("/"), j += b || (/^data\:|\?/.test(j) || c ? "" : ".js"), j = ("/" === j.charAt(0) || j.match(/^[\w\+\.\-]+:/) ? "" : g.baseUrl) + j
                }
                return g.urlArgs ? j + ((j.indexOf("?") === -1 ? "?" : "&") + g.urlArgs) : j
            },
            load: function (a, b) {
                req.load(d, a, b)
            },
            execCb: function (a, b, c, d) {
                return b.apply(d, c)
            },
            onScriptLoad: function (a) {
                if ("load" === a.type || readyRegExp.test((a.currentTarget || a.srcElement).readyState)) {
                    interactiveScript = null;
                    var b = F(a);
                    d.completeLoad(b.id)
                }
            },
            onScriptError: function (a) {
                var b = F(a);
                if (!t(b.id)) {
                    var c = [];
                    return eachProp(h, function (a, d) {
                        0 !== d.indexOf("_@r") && each(a.depMaps, function (a) {
                            return a.id === b.id && c.push(d), !0
                        })
                    }), y(makeError("scripterror", 'Script error for "' + b.id + (c.length ? '", needed by: ' + c.join(", ") : '"'), a, [b.id]))
                }
            }
        }, d.require = d.makeRequire(), d
    }

    function getInteractiveScript() {
        return interactiveScript && "interactive" === interactiveScript.readyState ? interactiveScript : (eachReverse(scripts(), function (a) {
            if ("interactive" === a.readyState) return interactiveScript = a
        }), interactiveScript)
    }
    var req, s, head, baseElement, dataMain, src, interactiveScript, currentlyAddingScript, mainScript, subPath, version = "2.1.22",
        commentRegExp = /(\/\*([\s\S]*?)\*\/|([^:]|^)\/\/(.*)$)/gm,
        cjsRequireRegExp = /[^.]\s*require\s*\(\s*["']([^'"\s]+)["']\s*\)/g,
        jsSuffixRegExp = /\.js$/,
        currDirRegExp = /^\.\//,
        op = Object.prototype,
        ostring = op.toString,
        hasOwn = op.hasOwnProperty,
        ap = Array.prototype,
        isBrowser = !("undefined" == typeof window || "undefined" == typeof navigator || !window.document),
        isWebWorker = !isBrowser && "undefined" != typeof importScripts,
        readyRegExp = isBrowser && "PLAYSTATION 3" === navigator.platform ? /^complete$/ : /^(complete|loaded)$/,
        defContextName = "_",
        isOpera = "undefined" != typeof opera && "[object Opera]" === opera.toString(),
        contexts = {},
        cfg = {},
        globalDefQueue = [],
        useInteractive = !1;
    if ("undefined" == typeof define) {
        if ("undefined" != typeof requirejs) {
            if (isFunction(requirejs)) return;
            cfg = requirejs, requirejs = void 0
        }
        "undefined" == typeof require || isFunction(require) || (cfg = require, require = void 0), req = requirejs = function (a, b, c, d) {
            var e, f, g = defContextName;
            return isArray(a) || "string" == typeof a || (f = a, isArray(b) ? (a = b, b = c, c = d) : a = []), f && f.context && (g = f.context), e = getOwn(contexts, g), e || (e = contexts[g] = req.s.newContext(g)), f && e.configure(f), e.require(a, b, c)
        }, req.config = function (a) {
            return req(a)
        }, req.nextTick = "undefined" != typeof setTimeout ? function (a) {
            setTimeout(a, 4)
        } : function (a) {
            a()
        }, require || (require = req), req.version = version, req.jsExtRegExp = /^\/|:|\?|\.js$/, req.isBrowser = isBrowser, s = req.s = {
            contexts: contexts,
            newContext: newContext
        }, req({}), each(["toUrl", "undef", "defined", "specified"], function (a) {
            req[a] = function () {
                var b = contexts[defContextName];
                return b.require[a].apply(b, arguments)
            }
        }), isBrowser && (head = s.head = document.getElementsByTagName("head")[0], baseElement = document.getElementsByTagName("base")[0], baseElement && (head = s.head = baseElement.parentNode)), req.onError = defaultOnError, req.createNode = function (a, b, c) {
            var d = a.xhtml ? document.createElementNS("http://www.w3.org/1999/xhtml", "html:script") : document.createElement("script");
            return d.type = a.scriptType || "text/javascript", d.charset = "utf-8", d.async = !0, d
        }, req.load = function (a, b, c) {
            var e, d = a && a.config || {};
            if (isBrowser) return e = req.createNode(d, b, c), d.onNodeCreated && d.onNodeCreated(e, d, b, c), e.setAttribute("data-requirecontext", a.contextName), e.setAttribute("data-requiremodule", b), !e.attachEvent || e.attachEvent.toString && e.attachEvent.toString().indexOf("[native code") < 0 || isOpera ? (e.addEventListener("load", a.onScriptLoad, !1), e.addEventListener("error", a.onScriptError, !1)) : (useInteractive = !0, e.attachEvent("onreadystatechange", a.onScriptLoad)), e.src = c, currentlyAddingScript = e, baseElement ? head.insertBefore(e, baseElement) : head.appendChild(e), currentlyAddingScript = null, e;
            if (isWebWorker) try {
                importScripts(c), a.completeLoad(b)
            } catch (d) {
                a.onError(makeError("importscripts", "importScripts failed for " + b + " at " + c, d, [b]))
            }
        }, isBrowser && !cfg.skipDataMain && eachReverse(scripts(), function (a) {
            if (head || (head = a.parentNode), dataMain = a.getAttribute("data-main")) return mainScript = dataMain, cfg.baseUrl || (src = mainScript.split("/"), mainScript = src.pop(), subPath = src.length ? src.join("/") + "/" : "./", cfg.baseUrl = subPath), mainScript = mainScript.replace(jsSuffixRegExp, ""), req.jsExtRegExp.test(mainScript) && (mainScript = dataMain), cfg.deps = cfg.deps ? cfg.deps.concat(mainScript) : [mainScript], !0
        }), define = function (a, b, c) {
            var d, e;
            "string" != typeof a && (c = b, b = a, a = null), isArray(b) || (c = b, b = null), !b && isFunction(c) && (b = [], c.length && (c.toString().replace(commentRegExp, "").replace(cjsRequireRegExp, function (a, c) {
                b.push(c)
            }), b = (1 === c.length ? ["require"] : ["require", "exports", "module"]).concat(b))), useInteractive && (d = currentlyAddingScript || getInteractiveScript(), d && (a || (a = d.getAttribute("data-requiremodule")), e = contexts[d.getAttribute("data-requirecontext")])), e ? (e.defQueue.push([a, b, c]), e.defQueueMap[a] = !0) : globalDefQueue.push([a, b, c])
        }, define.amd = {
            jQuery: !0
        }, req.exec = function (text) {
            return eval(text)
        }, req(cfg)
    }
}(this);
var $event = $.event,
    $special, resizeTimeout;
$special = $event.special.debouncedresize = {
    setup: function () {
        $(this).on("resize", $special.handler)
    },
    teardown: function () {
        $(this).off("resize", $special.handler)
    },
    handler: function (a, b) {
        var c = this,
            d = arguments,
            e = function () {
                a.type = "debouncedresize", $event.dispatch.apply(c, d)
            };
        resizeTimeout && clearTimeout(resizeTimeout), b ? e() : resizeTimeout = setTimeout(e, $special.threshold)
    },
    threshold: 250
}, Function.prototype.bind || (Function.prototype.bind = function (a) {
    if ("function" != typeof this) throw new TypeError("Function.prototype.bind - what is trying to be bound is not callable");
    var b = Array.prototype.slice.call(arguments, 1),
        c = this,
        d = function () { },
        e = function () {
            return c.apply(this instanceof d ? this : a, b.concat(Array.prototype.slice.call(arguments)))
        };
    return this.prototype && (d.prototype = this.prototype), e.prototype = new d, e
}), $(document).ready(function () {
    function s() {
        d.fadeOut(300)
    }

    function t() {
        return "none" !== $(".global-header .mobile-controls").css("display")
    }

    function u(b) {
        if (e) {
            var c = b.offset().left - a.offset().left + b.width() / 2;
            b.find(".nav-arrow-down").css({
                left: c
            })
        }
    }

    function B(a) {
        if (t()) {
            var b = a.height() - y.height();
            x.height(b), A.height($(window).height())
        } else x.removeAttr("style"), A.removeAttr("style")
    }

    function D() {
        x.hasClass("oc-menu-open") ? F() : E()
    }

    function E() {
        w.addClass("oc-menu-open")
    }

    function F() {
        w.removeClass("oc-menu-open"), $(".toggle-sub-nav").removeClass("open").addClass("closed"), $(".sub-nav").removeClass("secondary-open")
    }
    "table" == $(".top-level-nav").css("display") && $("body").addClass("no-flex");
    var l, a = $("#navigation.main-navigation"),
        b = a.find(".nav-item"),
        c = b.has(".sub-nav"),
        d = a.find(".sub-nav"),
        e = a.hasClass("megadropdown"),
        f = a.hasClass("dropdown"),
        g = a.hasClass("singleLevel"),
        h = a.hasClass("off-canvas"),
        j = a.hasClass("auto-highlight"),
        k = 300,
        m = Modernizr.touch,
        n = "ontouchstart" in window || navigator.MaxTouchPoints > 0 || navigator.msMaxTouchPoints > 0,
        o = !1;
    $(window).on("mousemove", function () {
        o && (touchmode = !1)
    });
    var p = "",
        q = location.href.split("/");
    if ("undefined" != typeof defaultActiveLink && (p = new RegExp("^" + defaultActiveLink + "$", "i")), b.each(function () {
        var a = $(this),
            b = a.find(".first-level-link");
        if (p) b.text().match(p) && a.addClass("active");
        else if (j && b.attr("href")) {
            var c = b[0].href.split("/");
            c.length > 4 && q[3] == c[3] && a.addClass("active")
        }
    }), c.each(function () {
        var a = $(this).find(".second-level-nav > li").length;
        a <= 2 && $(this).find(".sub-nav").addClass("with-few-items")
    }), e || f) {
        var r = $('<div class="nav-arrow-container"><div class="nav-arrow-down"></div></div>');
        d.append(r)
    }
    if (!e && !f || !m && n ? (e || f) && n && ($(document).on("click.ca.catchNav", function (b) {
        a.is(b.target) || 0 !== a.has(b.target).length || s()
    }), c.each(function () {
        var a = $(this),
            b = a.find(".first-level-link"),
            d = (b[0], a.find(".sub-nav"));
        d.find("a");
        b.data("link", b.attr("href")), a.on("click.ca.propagation", function (a) {
            a.stopPropagation()
        }), b.on("click.ca.navclose", function (b) {
            d.is(":visible") || t() || (b.preventDefault(), b.stopPropagation(), u(a), s(), d.fadeIn(300))
        })
    })) : (c.on("mouseenter.ca.navshow", function () {
        if (!t() && !o) {
            var a = $(this);
            l = setTimeout(function () {
                var b = a.find(".sub-nav").css("display", "none");
                b.css({
                    display: "block",
                    opacity: 0
                }).stop(!0, !0).delay(300).animate({
                    opacity: 1
                }, 300), u(a)
            }, k)
        }
    }), c.on("mouseleave.ca.navclose", function () {
        if (!t() && !o) {
            clearTimeout(l);
            var a = $(this).find(".sub-nav");
            a.animate({
                opacity: 0
            }, 300, function () {
                $(this).removeAttr("style")
            })
        }
    }), m && ($(document).on("touchstart.ca.catchNav", function (a) {
        o = !1, s()
    }, !1), c.each(function () {
        var a = $(this),
            b = a.find(".first-level-link"),
            d = (b[0], a.find(".sub-nav"));
        d.find("a");
        b.data("link", b.attr("href")).removeAttr, a.on("touchstart.ca.propagation", function (a) {
            a.stopPropagation()
        }), a.on("touchstart.ca.navclose", function (b) {
            o = !0, d.is(":visible") || t() || (b.preventDefault(), b.stopPropagation(), u(a), s(), d.fadeIn(300))
        }, !1)
    }))), g || c.each(function () {
        $(this).find(".first-level-link").addClass("has-sub");
        var a = $('<span class="mobile-control toggle-sub-nav closed"><span class="ca-gov-icon-menu-toggle-closed" aria-hidden="true"></span><span class="ca-gov-icon-menu-toggle-open" aria-hidden="true"></span><span class="sr-only">Sub Menu Toggle</span></span>');
        $(this).find(".sub-nav").before(a), a.click(function () {
            var a = $(this).parent().find(".sub-nav");
            a.is(":visible") ? ($(this).removeClass("open").addClass("closed"), a.slideUp("fast", function () {
                $(this).removeAttr("style").removeClass("secondary-open")
            })) : ($(this).removeClass("closed").addClass("open"), a.slideDown("fast", function () {
                $(this).removeAttr("style").addClass("secondary-open")
            }))
        })
    }), h) {
        $("body").addClass("off-canvas-enabled"), $("body > .oc-outer")[0] || $("body").wrapInner('<div class="oc-outer"><div class="oc-inner"></div></div>');
        var v = !0,
            w = $(".oc-outer"),
            x = $(".global-header .navigation-search").addClass("oc-menu"),
            y = $(".mobile-controls"),
            z = $(".toggle-menu"),
            A = $(".header-decoration");
        v && w.addClass("scroll-menu-only");
        var C = v ? $(window) : $("body");
        $(window).resize(function () {
            B(C)
        }), B(C), $("nav a").last().blur(function () {
            setTimeout(function () {
                $(document.activeElement).closest("nav.main-navigation").length || F()
            }, 1)
        }), z.click(function () {
            D()
        }).attr("tabindex", 0).focus(function () {
            E()
        }), A.click(function () {
            F()
        })
    } else $("#navigation").addClass("mobile-closed"), $(".toggle-menu").click(function () {
        $("#navigation").toggleClass("mobile-closed"), $(".search-container").removeClass("active")
    }), $(".toggle-search").on("click", function () {
        $(".search-container").toggleClass("active"), $("#navigation").hasClass("active") || $("#navigation").addClass("mobile-closed")
    });
    var G = "focus",
        H = "clickedFocus";
    $(".top-level-nav > li > a").hover(function () {
        $(this).closest("ul").find("." + G).removeClass(G)
    }, function () {
        $("." + H).removeClass(H)
    }), $(".top-level-nav > li > a").focus(function (a) {
        $(this).closest("ul").find("." + G).removeClass(G), $(this).parent().find(".toggle-sub-nav").hasClass("open") || $(this).parent().addClass(G)
    }).on("mousedown", function () {
        $(this).parent().find(".toggle-sub-nav").hasClass("open") || $(this).parent().addClass(H)
    }), $(".top-level-nav a").last().keydown(function (a) {
        9 == a.keyCode && $(".top-level-nav ." + G).removeClass(G)
    }), $(document).click(function () {
        $(".top-level-nav ." + G).removeClass(G)
    }), $(".top-level-nav").click(function (a) {
        a.stopPropagation()
    })
}), $(document).ready(function () {
    $(".accordion-list").find(".description").hide().attr("aria-hidden", "true");
    $(".accordion-list .toggle").attr("tabindex", "0").attr("aria-expanded", "false"), $(".accordion-list .toggle").click(function (a) {
        var b = $(this).next(".description");
        return b.is(":visible") ? (b.slideUp("fast").removeClass("hide").attr("aria-hidden", "true"), $(this).parent("li").removeClass("open"), $(this).attr("aria-expanded", "false")) : (b.slideDown("fast").removeClass("hide").attr("aria-hidden", "false"), $(this).parent("li").addClass("open"), $(this).attr("aria-expanded", "true")), !1
    })
}), $(document).ready(function () {
    $(".main-secondary .panel").first().addClass("first"), $(".panel.highlight").find(".panel-heading").prepend("<span class='triangle'></span>")
}), $(document).ready(function () {
    function f() {
        d.addClass("active-search"), a.addClass("active"), c.addClass("visible"), $("#navigation").addClass("mobile-closed"), $(".ask-group").addClass("fade-out"), $(window).scroll(), $.event.trigger("cagov.searchresults.show")
    }

    function g() {
        d.removeClass("active-search"), b.val(""), a.removeClass("active"), c.removeClass("visible"), $(".ask-group").removeClass("fade-out"), $(window).scroll(), $.event.trigger("cagov.searchresults.hide")
    }
    var a = $("#head-search"),
        b = a.find(".search-textfield"),
        c = $(".search-results-container"),
        d = $("body");
    $(".search-tabs button").click(function (a) {
        $(this).siblings().removeClass("active"), $(this).tab("show").addClass("active"), a.preventDefault()
    });
    b.on("blur focus", function (a) {
        $(this).parents("#head-search").removeClass("focus"), $(this).parents(".search-container").addClass("focus")
    }), b.on("change keyup paste", function () {
        $(this).val() && f()
    }), c.find(".close").on("click", g), a.find(".close").on("click", g), $(".top-level-nav .nav-item .ca-gov-icon-search, #nav-item-search").parents(".nav-item").on("click", function (a) {
        b.focus().trigger("focus"), $(".primary #head-search").addClass("play-animation").one("webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend", function () {
            $(this).removeClass("play-animation")
        }), window.setTimeout(function () {
            $("body:not(.primary) .search-container").addClass("active")
        }, 401)
    }), $(".close-search").on("click", g)
}), requirejs.config({
    baseUrl: "/Content/stateTemplate/js/libs"
}), $(document).ready(function () {
    fakewaffle.responsiveTabs(["xs", "sm"]), $(".eqHeight").eqHeight()
}), $(document).ready(function () {
    $(".gallery .item a, .carousel-gallery .item a, a.gallery-item").fancybox({
        groupAttr: "data-gallery"
    }), $(".gallery").eqHeight(".item"), $('a[data-toggle="tab"]').on("shown.bs.tab", function (a) {
        window.dispatchEvent(new Event("resize"))
    })
}), $(document).ready(function () {
    $(".main-secondary").eqHeight(".profile-banner > .inner")
    }), $(document).ready(function () {
    return; //hotfix
    $(".carousel-video").initCAVideo(), $(".carousel-content").each(initContent),
        function (a) {
            a.fn.owlBannerCarousel = function (b) {
                var c = a.extend({
                    delay: 4e3,
                    smallSearch: !0
                }, b);
                return this.each(function () {
                    c.smallSearch && a(".navigation-search").addClass("small-search");
                    var b = a(".header-slideshow-banner");
                    b.addClass("enabled"), window.setTimeout(function () {
                        var c = 450,
                            d = b.offset().top,
                            e = a(window).height(),
                            f = e - d;
                        f = f > c ? c : f, b.css({
                            height: f
                        })
                    }, 0);
                    var d = a(this),
                        e = a("html").hasClass("oldie") ? 0 : 250;
                    d.owlCarousel({
                        items: 1,
                        smartSpeed: e,
                        animateOut: "fadeOut",
                        loop: !0,
                        autoplay: !0,
                        autoplayTimeout: c.delay,
                        autoplayHoverPause: !1,
                        mouseDrag: !1,
                        touchDrag: !1,
                        pullDrag: !1,
                        pagination: !0,
                        dotsClass: "banner-pager",
                        dotClass: "banner-control",
                        dotsContainer: !1
                    });
                    var f = a('<div class="banner-play-pause"><div class="banner-control"><span class="play ca-gov-icon-carousel-play" aria-hidden="true"></span><span class="pause ca-gov-icon-carousel-pause" aria-hidden="true"></span></div></div>');
                    d.append(f);
                    var g = f.find(".play").hide(),
                        h = f.find(".pause");
                    g.on("click", function () {
                        a(this).hide(), a(this).parent().removeClass("active"), h.show(), d.trigger("play.owl.autoplay", [c.delay]), d.owlCarousel("next")
                    }), h.on("click", function () {
                        a(this).hide(), a(this).parent().addClass("active"), g.show(), d.trigger("stop.owl.autoplay")
                    });
                    var i = a(".banner-pager .banner-control");
                    i.each(function () {
                        a(this).find("span").append(a(this).index() + 1)
                    })
                })
            }
        }(jQuery), $("body .carousel-banner").owlBannerCarousel(), $.fn.owlCarousel && ($(".carousel-media").owlCarousel({
            onResized: function () {
                window.setTimeout(function () {
                    $(window).trigger("resize")
                }, 0)
            },
            onDragged: function () {
                window.setTimeout(function () {
                    $(window).trigger("resize")
                }, 0)
            },
            onTranslated: function () {
                window.setTimeout(function () {
                    $(window).trigger("resize")
                }, 0)
            },
            responsive: !0,
            margin: 10,
            nav: !0,
            loop: !0,
            responsiveClass: !0,
            responsive: {
                0: {
                    items: 1,
                    nav: !0
                },
                400: {
                    items: 2
                },
                700: {
                    items: 3,
                    nav: !0
                },
                1e3: {
                    items: 4,
                    nav: !0
                }
            },
            navText: ['<span class="ca-gov-icon-arrow-prev" aria-hidden="true"></span>', '<span class="ca-gov-icon-arrow-next" aria-hidden="true"></span>'],
            dots: !1
        }), $(".carousel-link").owlCarousel({
            margin: 25,
            autoWidth: !0,
            nav: !0,
            navText: ['<span class="ca-gov-icon-arrow-prev" aria-hidden="true"></span>', '<span class="ca-gov-icon-arrow-next" aria-hidden="true"></span>'],
            dots: !1
        }), $(".carousel-slider").owlCarousel({
            items: 1,
            nav: !0,
            navText: ['<span class="ca-gov-icon-arrow-prev" aria-hidden="true"></span>', '<span class="ca-gov-icon-arrow-next" aria-hidden="true"></span>'],
            dots: !1
        }), $(".carousel-gallery").owlCarousel({
            items: 1,
            nav: !0,
            navText: ['<span class="ca-gov-icon-arrow-prev" aria-hidden="true"></span>', '<span class="ca-gov-icon-arrow-next" aria-hidden="true"></span>'],
            dots: !1
        }))
}),
    function (a) {
        a.fn.initCAVideo = function (b) {
            return this.each(function () {
                function j() {
                    h.find(".watching").removeClass("watching"), h.find('img[src*="' + e + '"]').parents(".owl-item").addClass("watching")
                }
                var b = a(this),
                    c = b.attr("data-loaded");
                if (!c) {
                    b.attr("data-loaded", "true");
                    var d = b.find(".item a").first().attr("href") || "",
                        e = d.split("?v=").pop(),
                        f = 0,
                        g = b.find(".item").length;
                    b.owlCarousel({
                        items: 1,
                        loop: !1,
                        nav: !0,
                        lazyLoad: !1,
                        video: !0,
                        navText: ['<span class="ca-gov-icon-arrow-prev" aria-hidden="true"></span>', '<span class="ca-gov-icon-arrow-next" aria-hidden="true"></span>'],
                        dots: !1
                    }), b.on("translated.owl.carousel", function (a) {
                        e = b.find(".owl-item.active").attr("data-video").split(/\?v=|\/v\//).pop(), j(), f = a.item.index, h.trigger("to.owl.carousel", [f, 300, !0])
                    }), b.find(".owl-video-play-icon").append(a('<span class="ca-gov-icon-play" />')), b.find(".owl-video-tn").after(a("<div />").addClass("item-overlay"));
                    var h = a("<div></div>").insertAfter(b);
                    h.addClass("carousel owl-carousel carousel-video-submenu");
                    var i = b.find("a.owl-video");
                    i.each(function (c) {
                        var d = a(this),
                            e = d.attr("href"),
                            f = a("<div/>").addClass("item-thumbnail");
                        f.on("click", function () {
                            b.trigger("to.owl.carousel", [c % g, 300, !0]), h.find(".watching").removeClass("watching"), a(this).parents(".owl-item").addClass("watching"), b.find(".active .owl-video-play-icon").trigger("click")
                        });
                        var j = (new RegExp("ab+c", "i"), e.split(/\?v=|\/v\//).pop()),
                            k = "http://img.youtube.com/vi/" + j + "/0.jpg",
                            l = a("<img />").attr("src", k),
                            m = a("<div />").addClass("item-overlay");
                        m.append(a('<span class="ca-gov-icon-play" />')), f.append(l).append(m), h.append(f)
                    }), h = b.next(), h.on("initialized.owl.carousel", function () {
                        j()
                    }), h.owlCarousel({
                        items: 4,
                        loop: !1,
                        nav: !0,
                        margin: 20,
                        dots: !1,
                        navText: ['<span class="ca-gov-icon-arrow-prev" aria-hidden="true"></span>', '<span class="ca-gov-icon-arrow-next" aria-hidden="true"></span>']
                    }), h.on("changed.owl.carousel", function () {
                        setTimeout(j, 50)
                    })
                }
            })
        }
    }(jQuery), $(document).ready(function () {
        $(".job-detail").eqHeight(".well")
    }), $(document).ready(function () {
        $(".location.full").eqHeight(".photo, .map")
    }), $(document).ready(function () {
        function c(a) {
            var b = /<\S[^>]*>/g;
            return a = a.replace(b, " ")
        }

        function d(a, b, c, d) {
            var e = window.screenX ? window.screenX : window.screenLeft ? window.screenLeft : screen.left ? screen.left : 0,
                f = window.screenY ? window.screenY : window.screenTop ? window.screenTop : screen.top ? screen.top : 0,
                g = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width,
                h = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height,
                i = g / 2 - c / 2 + e,
                j = h / 2 - d / 2 + f;
            window.open(a, b, "scrollbars=yes, width=" + c + ", height=" + d + ", left=" + i + ", top=" + j)
        }
        var a = c(document.title),
            b = window.location.href;
        b = encodeURIComponent(c(b)), $(".ca-gov-icon-share-facebook").on("click", function (a) {
            d("https://www.facebook.com/sharer/sharer.php?u=" + b + "&display=popup", "socialsharer", "658", "450")
        }), $(".ca-gov-icon-share-twitter").on("click", function (c) {
            d("https://twitter.com/intent/tweet?text=" + a + "&url=" + b, "socialsharer", "568", "531")
        }), $(".ca-gov-icon-share-googleplus").on("click", function (a) {
            d("https://plus.google.com/share?url=" + b, "socialsharer", "550", "552")
        }), $(".ca-gov-icon-share-email").attr("href", "mailto:?subject=" + a + "&body=%0a" + b + "%0a%0a")
    }), $(document).ready(function () {
        breadcrumbs()
    }), $(document).ready(function () {
        $(".service-group").each(initServiceGroup)
    });
var __$currentRow = null;
$(document).ready(function () {
    $(".number-counter").each(initCountUp)
}), String.prototype.trim || (String.prototype.trim = function () {
    return this.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, "")
}), $(document).ready(function () {
    var a = $(".header-single-banner, .header-large-banner, .header-primary-banner"),
        b = $(".header-large-banner"),
        c = $(".header-primary-banner"),
        d = $(window).height(),
        e = $("header"),
        f = $(".ask-group"),
        g = $("#head-search");
    setTimeout(function () {
        f.addClass("in"), g.addClass("in")
    }, 150), window.headerVars = {
        MOBILEWIDTH: 767,
        MAXHEIGHT: 1200,
        MINHEIGHT: 500,
        setHeaderImageHeight: function () {
            if (0 != a.length) {
                var f = d;
                f = Math.max(Math.min(f, headerVars.MAXHEIGHT), headerVars.MINHEIGHT);
                var g = a.offset().top;
                a.css({
                    height: f - e.height()
                })
                    , headerImageHeight = a.height(), b.css({
                    height: f - g
                }), headerImageHeight = b.height(), c.css({
                    height: 450
                })
            }
        }
        }
    , headerVars.setHeaderImageHeight();
    var h = a.css("background-image"),
        i = $(".ask-group");
    i.attr("style", "background-size: cover; background-repeat: no-repeat; background-image:" + h)
    }),
    $(document).ready(function () {
    function r() {
        window.setTimeout(function () {
            if (!k.hasClass("active") && g.hasClass("fixed") && !(p >= a)) {
                return; //broken line below with the getBoundingClientRect() method, early return to skip it, hotfix
                var b = k.get(0).getBoundingClientRect(),
                    d = b.top + b.height + c;
                j.css("top", d), j.trigger("cagov.askgroup.update")
            }
        }, 0)
    }

    function t() {
        d.hasClass("fixed") && $(window).on("resize", function () {
            n = $(window).height(), o = $(window).width(), m = g.innerHeight(), q = y(), o > headerVars.MOBILEWIDTH ? (A(), r()) : B(), r()
        })
    }

    function u() {
        var a;
        a = d.hasClass("fixed") ? function () {
            o < headerVars.MOBILEWIDTH || (w(), v())
        } : function () {
            x()
        }, $(window).on("scroll", function () {
            p = $(document).scrollTop(), a(), x()
        }), a()
    }

    function v() {
        if (k.hasClass("active")) return i.addClass("fixed-hide"), void d.addClass("compact, .fixed")
    }

    function w() {
        p >= b ? (i.addClass("fixed-hide"), k.addClass("fixed-hide")) : (i.removeClass("fixed-hide"), k.removeClass("fixed-hide")), p >= a ? d.addClass("compact") : d.hasClass("compact") && d.removeClass("compact")
    }

    function x() {
        p >= a ? s.addClass("is-visible") : s.removeClass("is-visible")
    }

    function y() {
        return f.length && j.length ? k.height() + j.height() : 0
    }

    function z() {
        d.hasClass("fixed") && o > headerVars.MOBILEWIDTH ? A() : B()
    }

    function A() {
        var a = 10;
        if (d.addClass("fixed"), headerVars.setHeaderImageHeight(), e.length) {
            var b = e.height();
            b = Math.max(Math.min(b, headerVars.MAXHEIGHT), headerVars.MINHEIGHT), e.css({
                height: b + m + a
            })
        } else l.css({
            "padding-top": Math.max(m, 136)
        });
        $(".ask-group").length > 0 && (l.css({
            "padding-top": 0
        }), $(".header-slideshow-banner, .header-primary-banner").css({
            "margin-top": 136
        }))
    }

    function B() {
        d.removeClass("fixed"), e.css({
            top: "",
            "margin-bottom": ""
        }), l.css({
            "padding-top": ""
        }), j.css("top", "")
    }
    var a = 220,
        b = 80,
        c = 10,
        d = $("header"),
        e = $(".header-single-banner"),
        f = $(".explore-invite"),
        g = $(".global-header"),
        h = $(".alert-banner"),
        i = $(".ask-group"),
        j = $("#askGroup"),
        k = $("#head-search"),
        l = $("#main-content"),
        m = g.innerHeight(),
        n = $(window).height(),
        o = $(window).width(),
        p = $(document).scrollTop(),
        q = y();
    r(), k.bind("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd", function () {
        r()
    });
    var s = $('<span class="return-top"/>').appendTo(".main-content");
    t(), u(),
        function (a) {
            a.fn.customScrollTop = function () {
                return this.each(function () {
                    $el = a(this), $el.on("click", function () {
                        a("html,body").animate({
                            scrollTop: 0
                        }, 400, function () {
                            a(window).scroll()
                        })
                    })
                })
            }
        }(jQuery), $('[href="#skip-to-content"]').customScrollTop(), s.customScrollTop(), d.hasClass("fixed") && $("#nav-item-search").customScrollTop(), z(), h.on("closed.bs.alert", function () {
            m = g.innerHeight(), z(), r()
        })
}), $(function () {
    $(".stats-highlight").each(initStats), $(".plotly-chart").each(initPlotly)
});
var defaultBar = [{
    type: "bar",
    x: [],
    y: [],
    marker: {
        color: "#046B99",
        line: {
            width: .5
        }
    }
}],
    defaultLine = [{
        x: [],
        y: [],
        mode: "lines",
        name: "Solid",
        line: {
            color: "#046B99",
            dash: "solid",
            width: 4
        }
    }],
    defaultPie = [{
        values: [],
        labels: [],
        hoverinfo: "label+percent",
        type: "pie",
        marker: {
            colors: ["#E1F2F7", "#9FDBF1", "#02BFE7", "#35BBAA", "#72CE6F", "#815AB4", "#D34A37", "#F27E31", "#FFCA4A"]
        }
    }];
! function (a) {
    a.fn.parallax = function (b) {
        var d = (a(window).height(), a.extend({
            speed: .3
        }, b));
        return this.each(function () {
            var b = a(this),
                c = a(window).outerHeight() * d.speed + b.innerHeight();
            b.css({
                height: c
            }), a(window).scroll(function () {
                var g, c = b.offset().top,
                    e = a(window).scrollTop(),
                    f = (e + a(window).innerHeight() - c) * d.speed;
                g = "translate(0, " + f + "px)", b.css({
                    "-webkit-transform": g,
                    "-moz-transform": g,
                    "-ms-transform": g,
                    transform: g
                })
            })
        })
    }
}(jQuery), $(".parallax-bg").parallax(), $(document).ready(function () {
    $("[class*='animate-']").each(initAnimations)
}), $(document).ready(function () {
    $(".toggle-more").toggleMore(), $("[data-ajax-target]").each(initLoad);
    var a = $("html, body");
    $(".explore-invite").on("click", function (b) {
        b.preventDefault();
        var c = $("header.fixed").height();
        a.animate({
            scrollTop: $(".main-primary").offset().top - c
        }, 2e3), $(document).one("scroll mousedown DOMMouseScroll mousewheel keyup touchstart", function (b) {
            (b.which > 0 || "mousedown" === b.type || "mousewheel" === b.type || "touchstart" == b.type) && a.stop()
        })
    })
}),
    function (a) {
        a.fn.toggleMore = function (b) {
            function c(a, b) {
                b ? a.addClass("active").attr("aria-expanded", "true") : a.removeClass("active").attr("aria-expanded", "false")
            }
            return this.each(function () {
                var d = a(this);
                void 0 !== b ? b ? c(d, !0) : c(d, !1) : d.hasClass("active") ? c(d, !0) : c(d, !1), d.off("click.cagovmore"), d.on("click.cagovmore", function () {
                    d.hasClass("active") ? c(d, !1) : c(d, !0)
                })
            })
        }
    }(jQuery), $(document).ready(function () {
        function e() {
            a.addClass("active"), b.removeClass("active"), c.addClass("high-contrast"), localStorage.setItem("high-contrast", "true")
        }

        function f() {
            b.addClass("active"), a.removeClass("active"), c.removeClass("high-contrast"), localStorage.removeItem("high-contrast")
        }

        function p(a) {
            var b = Math.min(l, Math.max(a, m));
            return localStorage.setItem("font-size", b), $("html").css("font-size", b + "rem"), q(b), b
        }

        function q(a) { }
        var a = $(".enableHighContrastMode"),
            b = $(".disableHighContrastMode"),
            c = $("html"),
            d = localStorage.getItem("high-contrast");
        d && e(), a.on("click", e), b.on("click", f);
        var g = $(".enableTextOnlyMode"),
            h = $(".disableTextOnlyMode");
        g.click(function () {
            g.addClass("active"), h.removeClass("active"), $('link[rel~="stylesheet"]').prop("disabled", !0)
        }), h.click(function () {
            h.addClass("active"), g.removeClass("active"), $('link[rel~="stylesheet"]').prop("disabled", !1)
        });
        var i = $(".increaseTextSize"),
            j = $(".decreaseTextSize"),
            k = $(".resetTextSize"),
            l = 1.5,
            m = 1,
            n = .1,
            o = +localStorage.getItem("font-size");
        o ? $("html").css("font-size", o + "rem") : (o = 1, $("html").css("font-size", o + "rem")), q(o), i.on("click", function () {
            o += n, o = p(o)
        }), j.on("click", function () {
            o -= n, o = p(o)
        }), k.on("click", function () {
            o = p(1)
        })
    }), $(document).ready(function () {
        function b() {
            var a = $(window).width();
            a < 767 && $("html, body").animate({
                scrollTop: 0
            }, 450), $("#locationSettings").collapse("show");
            var b = $("#locationSettings").find("input"),
                d = $("#locationSettings").find("button");
            b.keypress(function (a) {
                if (13 == a.which) return c.call(this, a), !1
            }), d.on("click", function (a) {
                a.preventDefault(), c.call(b, a)
            })
        }

        function c(b) {
            var c = $(this).val();
            a.html("Geo Locating...");
            var d = $.get(window.__getLocation + "?zip=" + c);
            d.done(e), d.fail(function () {
                a.html("Not Found")
            })
        }

        function d(c) {
            var d = {
                lat: c.coords.latitude,
                lng: c.coords.longitude,
                time: c.timestamp
            };
            a.html("Geo Locating...");
            var f = $.get(window.__getLocation + "?lat=" + d.lat + "&lng=" + d.lng);
            f.done(e), f.fail(function () {
                b(), a.html("Enter ZIP")
            })
        }

        function e(b) {
            var c = b.rows[0][0];
            b.rows[0][2];
            window._cagov_newlat = b.rows[0][3], window._cagov_newlng = b.rows[0][4], $("#locationSettings").collapse("hide"), a.html(c), $("[data-locations-landing],[data-locations]").first().loadMapThat(), $(".header-single-banner").each(function () {
                var a = $.get(window.__getImageByLocation);
                a.done(function (a) {
                    var b = 'url("' + a + '")',
                        c = $(".header-single-banner").css("background-image");
                    b !== c && ($(window).width() <= 767 ? ($(".ask-group").fadeOut("3000", function () {
                        $(this).css("background-image", "url(" + a + ")").fadeIn("3000")
                    }), $(".header-single-banner").css("background-image", "url(" + a + ")")) : ($(".header-single-banner").fadeOut("3000", function () {
                        $(this).css("background-image", "url(" + a + ")").fadeIn("3000", function () {
                            $(this).css("display", "")
                        })
                    }), $(".ask-group").css("background-image", "url(" + a + ")")))
                })
            })
        }

        function f(a) {
            return a ? decodeURIComponent(document.cookie.replace(new RegExp("(?:(?:^|.*;)\\s*" + encodeURIComponent(a).replace(/[\-\.\+\*]/g, "\\$&") + "\\s*\\=\\s*([^;]*).*$)|^.*$"), "$1")) || null : null
        }
        var a = $(".located-city-name");
        $(".geo-lookup").on("click", function (c) {
            c.preventDefault();
            var e = f("cagov__geo");
            return e ? (a.html("Enter ZIP"), void b()) : void (navigator.geolocation ? navigator.geolocation.getCurrentPosition(d, b) : b())
        }), $(".clear-geo").on("click", function (b) {
            b.preventDefault(), "undefined" == typeof location.origin && (location.origin = location.protocol + "//" + location.host), document.cookie = "cagov__geo=;path=/", a.html("Set Location"), $("#locationSettings").collapse("hide")
        })
    }), $(".ask-button").attr("tabindex", 0), $("body").on("click", function (a) {
        try {
            $(".ask-panel").collapse("hide")
        } catch (a) { }
    });