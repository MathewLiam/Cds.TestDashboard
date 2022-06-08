var gulp = require('gulp'),
    sass = require('gulp-sass')(require('sass')),
    webpackConfig = require('./webpack.config'),
    webpack = require('webpack-stream');

const scss = (done) => {
    gulp.src('./Cds.TestDashboard.Web/UI/scss/main.scss')
        .pipe(sass())
        .pipe(gulp.dest('./Cds.TestDashboard.Web/wwwroot/css'))

    done();
}

gulp.task(scss);

const ts = (done) => {
    gulp.src('./Cds.TestDashboard.Web/UI/ts/*.ts')
        .pipe(webpack(webpackConfig))
        .pipe(gulp.dest('./Cds.TestDashboard.Web/wwwroot/js'));

    done();
} 

gulp.task(ts);

const buildFrontend = gulp.series(ts, scss);


const watchWeb = () => {
    gulp.watch('./Cds.TestDashboard.Web/UI/**/*', (done) => buildFrontend(done));
}

gulp.task(watchWeb);

module.exports = {
    buildFrontend
}