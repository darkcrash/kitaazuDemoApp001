$(function () {
    app.initialize();

    // Knockout のアクティブ化
    ko.validation.init({ grouping: { observable: false } });
    ko.applyBindings(app);
});
