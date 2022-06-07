var gulp = require('gulp'),
    sass = require('gulp-sass')(require('sass'));

const scss = (done) => {
    gulp.src('./Cds.TestDashboard.Web/UI/scss/main.scss')
        .pipe(sass())
        .pipe(gulp.dest('./Cds.TestDashboard.Web/wwwroot/css'))

    done();
}

gulp.task(scss);
