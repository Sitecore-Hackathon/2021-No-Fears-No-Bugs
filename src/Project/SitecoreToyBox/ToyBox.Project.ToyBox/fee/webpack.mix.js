let mix = require('laravel-mix');
//mix.disableNotifications();
mix.setPublicPath('dist');

/*
 |--------------------------------------------------------------------------
 | Mix Asset Management
 |--------------------------------------------------------------------------
 |
 | Mix provides a clean, fluent API for defining some Webpack build steps
 | for your Laravel application. By default, we are compiling the Sass
 | file for your application, as well as bundling up your JS files.
 |
 */

mix.js('src/js/app.js', 'dist/js/')
    .sass('src/sass/app.scss', 'dist/css/');

mix.options({
    //   extractVueStyles: false, // Extract .vue component styling to file, rather than inline.
        processCssUrls: false, // Process/optimize relative stylesheet url()'s. Set to false, if you don't want them touched.
    //   purifyCss: false, // Remove unused CSS selectors.
    //   uglify: {}, // Uglify-specific options. https://webpack.github.io/docs/list-of-plugins.html#uglifyjsplugin
    //   postCss: [] // Post-CSS options: https://github.com/postcss/postcss/blob/master/docs/plugins.md
    });