var gulp = require('gulp');
var sass = require('gulp-sass');
var watch = require('gulp-watch');
var browserSync = require('browser-sync').create();
var concat = require('gulp-concat');


gulp.task('sass', function(){
  return gulp.src('scss/styles.scss')
    .pipe(sass()) 
    .pipe(gulp.dest('content/css'))
    .pipe(browserSync.reload({
      stream: true
    }))
});

gulp.task('watch', ['browserSync', 'sass', 'scripts'], function () {
    gulp.watch('scss/**/*.scss' , ['sass']);
    gulp.watch('scripts/**/*.js' , ['scripts']);

});


//gulp.task('browserSync', function() {
//  browserSync.init({
//    server: {
//      baseDir: 'app'
//    },
//  })
//});

gulp.task('scripts', function() {
  return gulp.src('scripts/**/*.js')
    .pipe(concat('scripts.js'))
    .pipe(gulp.dest('content/js'));
});