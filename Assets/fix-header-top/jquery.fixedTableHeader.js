/**
 * Fixed Table Header Plugin for jQuery
 *
 * @version 1.0.0
 * @license MIT
 * @author Kiyofumi Torigoe (kiyotd, torigoedesign)
 * @copyright 2021 Kiyofumi Torigoe
 */
(function ($) {

  const defaultTarget = "thead";

  const defaultCss = {
    position: "sticky",
    top: 0,
    //background: "#31708f",
    //color: "#E9EDEF"
  };

  $.fn.fixedTableHeader = function (target = null, css = null) {

    target = target ?? defaultTarget;
    css = css ?? defaultCss;

    const resultCss = Object.assign({}, defaultCss, css)
    // const resultCss = { ...defaultCss, ...css }

    $(target, this).css(resultCss);
    return this;

  }
})(jQuery);
