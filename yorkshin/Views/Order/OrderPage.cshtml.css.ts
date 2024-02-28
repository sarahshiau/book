/* [Master Stylesheet - v1.0] */
/* :: 1.0 Import Fonts */
@import url("https://fonts.googleapis.com/css?family=Archivo+Narrow:400,400i,500,500i,600,600i,700,700i");
/* :: 2.0 Import All CSS */
@import url(css/classy-nav.css);
@import url(css/font-awesome.min.css);
@import url(./css/Info.css);
@import url(./css/tabs.css);
@import url(./css/card.css);
/* :: 3.0 Base CSS */
* {
    margin: 0;
    padding: 0; }

body {
    /*font-family: "Archivo Narrow", sans-serif;*/
    font-family: 'Times New Roman', Times, serif;
    font-size: 14px; }

h1,
    h2,
    h3,
    h4,
    h5,
    h6 {
    /*font-family: "Archivo Narrow", sans-serif;*/
    font-family: 'Times New Roman', Times, serif;
    color: #000000;
    line-height: 1.3;
    font-weight: 700; }

p {
    /*font-family: "Archivo Narrow", sans-serif;*/
    font-family: 'Times New Roman', Times, serif;
    color: #5f5f5f;
    font-size: 15px;
    line-height: 2;
    font-weight: 400; }

a,
    a:hover,
    a:focus {
    -webkit-transition-duration: 500ms;
    transition-duration: 500ms;
    text-decoration: none;
    outline: 0 solid transparent;
    color: #000000;
    font-weight: 700;
    font-size: 16px;
    /*font-family: "Archivo Narrow", sans-serif;*/
    font-family: 'Times New Roman', Times, serif; }

ul,
    ol {
    margin: 0; }
ul li,
    ol li {
    list-style: none; }

img {
    height: auto;
    max-width: 100%; }

/* :: 3.1.0 Spacing */
.mt-15 {
    margin-top: 15px !important; }

.mt-30 {
    margin-top: 30px !important; }

.mt-50 {
    margin-top: 50px !important; }

.mt-70 {
    margin-top: 70px !important; }

.mt-100 {
    margin-top: 100px !important; }

.mb-15 {
    margin-bottom: 15px !important; }

.mb-30 {
    margin-bottom: 30px !important; }

.mb-50 {
    margin-bottom: 50px !important; }

.mb-70 {
    margin-bottom: 70px !important; }

.mb-100 {
    margin-bottom: 100px !important; }

.ml-15 {
    margin-left: 15px !important; }

.ml-30 {
    margin-left: 30px !important; }

.ml-50 {
    margin-left: 50px !important; }

.mr-15 {
    margin-right: 15px !important; }

.mr-30 {
    margin-right: 30px !important; }

.mr-50 {
    margin-right: 50px !important; }

/* :: 3.2.0 Height */
.height-400 {
    height: 400px !important; }

.height-500 {
    height: 500px !important; }

.height-600 {
    height: 600px !important; }

.height-700 {
    height: 700px !important; }

.height-800 {
    height: 800px !important; }

/* :: 3.3.0 Section Padding */
.section-padding-100 {
    padding-top: 100px;
    padding-bottom: 100px; }

.section-padding-100-0 {
    padding-top: 100px;
    padding-bottom: 0; }

.section-padding-0-100 {
    padding-top: 0;
    padding-bottom: 100px; }

.section-padding-100-70 {
    padding-top: 100px;
    padding-bottom: 70px; }

/* :: 3.4.0 Section Heading */
.section-heading {
    position: relative;
    z-index: 1;
    margin-bottom: 100px;
    text-align: center; }
.section-heading p {
    color: #5f5f5f;
    font-size: 14px;
    margin-bottom: 5px; }
.section-heading h2 {
    font-size: 18px;
    text-transform: uppercase;
    letter-spacing: 10px;
    margin-bottom: 0; }
@media only screen and (max-width: 767px) {
.section-heading h2 {
        letter-spacing: 5px; } }
.section-heading.white h2 {
    color: #fff; }
.section-heading.style-2 p {
    font-size: 16px; }
.section-heading.style-2 h2 {
    font-size: 30px; }
@media only screen and (max-width: 767px) {
.section-heading.style-2 h2 {
        font-size: 24px; } }

/* :: 3.5.0 Preloader */
.preloader {
    background-color: #ffffff;
    width: 100%;
    height: 100%;
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    z-index: 99999; }
.preloader .lds-ellipsis {
    display: inline-block;
    position: relative;
    width: 64px;
    height: 64px; }
.preloader .lds-ellipsis div {
    position: absolute;
    top: 27px;
    width: 11px;
    height: 11px;
    border-radius: 50%;
    background: #000000;
    animation-timing-function: cubic-bezier(0, 1, 1, 0); }
.preloader .lds-ellipsis div:nth-child(1) {
    left: 6px;
    -webkit-animation: lds-ellipsis1 0.6s infinite;
    animation: lds-ellipsis1 0.6s infinite; }
.preloader .lds-ellipsis div:nth-child(2) {
    left: 6px;
    -webkit-animation: lds-ellipsis2 0.6s infinite;
    animation: lds-ellipsis2 0.6s infinite; }
.preloader .lds-ellipsis div:nth-child(3) {
    left: 26px;
    -webkit-animation: lds-ellipsis2 0.6s infinite;
    animation: lds-ellipsis2 0.6s infinite; }
.preloader .lds-ellipsis div:nth-child(4) {
    left: 45px;
    -webkit-animation: lds-ellipsis3 0.6s infinite;
    animation: lds-ellipsis3 0.6s infinite; }

@-webkit-keyframes lds-ellipsis1 {
    0% {
    -webkit-transform: scale(0);
    transform: scale(0); }
    100% {
    -webkit-transform: scale(1);
    transform: scale(1); } }
@keyframes lds-ellipsis1 {
    0% {
    -webkit-transform: scale(0);
    transform: scale(0); }
    100% {
    -webkit-transform: scale(1);
    transform: scale(1); } }
@-webkit-keyframes lds-ellipsis3 {
    0% {
    -webkit-transform: scale(1);
    transform: scale(1); }
    100% {
    -webkit-transform: scale(0);
    transform: scale(0); } }
@keyframes lds-ellipsis3 {
    0% {
    -webkit-transform: scale(1);
    transform: scale(1); }
    100% {
    -webkit-transform: scale(0);
    transform: scale(0); } }
@-webkit-keyframes lds-ellipsis2 {
    0% {
    -webkit-transform: translate(0, 0);
    transform: translate(0, 0); }
    100% {
    -webkit-transform: translate(19px, 0);
    transform: translate(19px, 0); } }
@keyframes lds-ellipsis2 {
    0% {
    -webkit-transform: translate(0, 0);
    transform: translate(0, 0); }
    100% {
    -webkit-transform: translate(19px, 0);
    transform: translate(19px, 0); } }
/* :: 3.6.0 Miscellaneous */
.bg-img {
    background-position: center center;
    background-size: cover;
    background-repeat: no-repeat; }

.bg-white {
    background-color: #ffffff !important; }

.bg-dark {
    background-color: #000000 !important; }

.bg-transparent {
    background-color: transparent !important; }

.bg-gray {
    background-color: #f5f9fa; }

.font-bold {
    font-weight: 700; }

.font-light {
    font-weight: 300; }

.bg-overlay {
    position: relative;
    z-index: 2;
    background-position: center center;
    background-size: cover; }
.bg-overlay::after {
    background-color: rgba(0, 0, 0, 0.65);
    position: absolute;
    z-index: -1;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    content: ""; }

.bg-fixed {
    background-attachment: fixed !important; }

/* :: 3.7.0 ScrollUp */
#scrollUp {
    background-color: #000000;
    border-radius: 0;
    bottom: 50px;
    box-shadow: 0 2px 6px 0 rgba(0, 0, 0, 0.3);
    color: #ffffff;
    font-size: 24px;
    height: 40px;
    line-height: 40px;
    right: 50px;
    text-align: center;
    width: 40px;
    -webkit-transition-duration: 500ms;
    transition-duration: 500ms;
    box-shadow: 0 1px 5px 2px rgba(0, 0, 0, 0.15); }
@media only screen and (max-width: 767px) {
    #scrollUp {
        right: 30px;
        bottom: 30px; } }
#scrollUp:hover {
    background-color: #fff;
    color: #232323; }

/* :: 3.8.0 oneMusic Button */
.oneMusic-btn {
    background-color: #fff;
    -webkit-transition-duration: 500ms;
    transition-duration: 500ms;
    position: relative;
    z-index: 1;
    display: inline-block;
    min-width: 212px;
    height: 49px;
    color: #000;
    border: 1px solid #000;
    border-radius: 0;
    padding: 0 30px;
    font-size: 16px;
    line-height: 47px;
    font-weight: 700;
    text-transform: capitalize; }
.oneMusic-btn i {
    margin-left: 5px; }
.oneMusic-btn:hover, .oneMusic-btn:focus {
    font-size: 16px;
    font-weight: 700;
    background-color: #000000;
    color: #fff; }
.oneMusic-btn.btn-2 {
    background-color: #000000;
    color: #fff; }
.oneMusic-btn.btn-2:hover, .oneMusic-btn.btn-2:focus {
    background-color: #fff;
    color: #232323; }

/* :: 4.0 Header Area CSS */
.header-area {
    position: absolute;
    z-index: 1000;
    width: 100%;
    top: 20px;
    left: 0;
    z-index: 1000; }
.header-area .oneMusic-main-menu {
    position: relative;
    width: 100%;
    height: 85px;
    background-color: transparent; }
@media only screen and (max-width: 767px) {
.header-area .oneMusic-main-menu {
        height: 70px; } }
.header-area .oneMusic-main-menu .classy-nav-container {
    background-color: transparent; }
.header-area .oneMusic-main-menu .classy-navbar {
    background-color: transparent;
    height: 85px;
    padding: 0; }
@media only screen and (max-width: 767px) {
.header-area .oneMusic-main-menu .classy-navbar {
        height: 70px; } }
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li a {
    font-weight: 700;
    text-transform: capitalize;
    color: #ffffff;
    font-size: 16px; }
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li a:hover, .header-area .oneMusic-main-menu .classy-navbar .classynav ul li a:focus {
    color: rgba(255, 255, 255, 0.7); }
@media only screen and (min-width: 768px) and (max-width: 991px) {
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li a {
        background-color: #000000;
        border-bottom-color: rgba(255, 255, 255, 0.1); } }
@media only screen and (max-width: 767px) {
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li a {
        background-color: #000000;
        border-bottom-color: rgba(255, 255, 255, 0.1); } }
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li.megamenu-item > a::after,
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li.has-down > a::after {
    color: #ffffff; }
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li.megamenu-item ul li > a::after,
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li.has-down ul li > a::after {
    color: #232323; }
@media only screen and (max-width: 767px) {
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li.megamenu-item ul li > a::after,
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li.has-down ul li > a::after {
        color: #ffffff; } }
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li ul li a {
    color: #232323; }
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li ul li a:hover, .header-area .oneMusic-main-menu .classy-navbar .classynav ul li ul li a:focus {
    color: #888888; }
@media only screen and (min-width: 992px) and (max-width: 1199px) {
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li ul li a {
        padding: 0 15px; } }
@media only screen and (min-width: 768px) and (max-width: 991px) {
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li ul li a {
        color: #ffffff;
        padding: 0 30px;
        border-bottom-color: rgba(255, 255, 255, 0.1); } }
@media only screen and (max-width: 767px) {
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li ul li a {
        color: #ffffff;
        padding: 0 30px;
        border-bottom-color: rgba(255, 255, 255, 0.1) !important; } }
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li .dropdown li .dropdown li .dropdown li a {
    border-bottom: 1px solid rgba(242, 244, 248, 0.7); }
@media only screen and (min-width: 768px) and (max-width: 991px) {
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li .dropdown li .dropdown li .dropdown li a {
        border-bottom-color: rgba(255, 255, 255, 0.1) !important; } }
@media only screen and (max-width: 767px) {
.header-area .oneMusic-main-menu .classy-navbar .classynav ul li .dropdown li .dropdown li .dropdown li a {
        border-bottom-color: rgba(255, 255, 255, 0.1) !important; } }
.header-area .oneMusic-main-menu .login-register-cart-button {
    position: relative;
    z-index: 1;
    margin-left: 100px; }
@media only screen and (min-width: 768px) and (max-width: 991px) {
.header-area .oneMusic-main-menu .login-register-cart-button {
        margin-left: 12px;
        margin-top: 15px; } }
@media only screen and (max-width: 767px) {
.header-area .oneMusic-main-menu .login-register-cart-button {
        margin-left: 12px;
        margin-top: 15px; } }
.header-area .oneMusic-main-menu .login-register-cart-button .login-register-btn {
    position: relative;
    z-index: 10; }
.header-area .oneMusic-main-menu .login-register-cart-button .login-register-btn a {
    -webkit-transition-duration: 500ms;
    transition-duration: 500ms;
    margin-bottom: 0;
    color: #fff;
    font-weight: 700;
    font-size: 16px;
    cursor: pointer;
    line-height: 1; }
.header-area .oneMusic-main-menu .login-register-cart-button .login-register-btn a:hover, .header-area .oneMusic-main-menu .login-register-cart-button .login-register-btn a:focus {
    color: rgba(255, 255, 255, 0.7); }
.header-area .oneMusic-main-menu .login-register-cart-button .cart-btn {
    position: relative;
    z-index: 10; }
.header-area .oneMusic-main-menu .login-register-cart-button .cart-btn p {
    -webkit-transition-duration: 500ms;
    transition-duration: 500ms;
    margin-bottom: 0;
    color: #fff;
    font-size: 18px;
    cursor: pointer;
    line-height: 1; }
.header-area .oneMusic-main-menu .login-register-cart-button .cart-btn p:hover, .header-area .oneMusic-main-menu .login-register-cart-button .cart-btn p:focus {
    color: rgba(255, 255, 255, 0.7); }
.header-area .oneMusic-main-menu .login-register-cart-button .cart-btn p .quantity {
    width: 15px;
    height: 15px;
    border: 1px solid #fff;
    background-color: #232323;
    color: #fff;
    display: block;
    position: absolute;
    bottom: -5px;
    left: -10px;
    z-index: 10;
    font-size: 9px;
    font-weight: 400;
    border-radius: 50%;
    line-height: 13px;
    text-align: center; }
.header-area .is-sticky .oneMusic-main-menu {
    position: fixed;
    width: 100%;
    height: 85px;
    top: 0;
    left: 0;
    z-index: 9999;
    background-color: #000000;
    box-shadow: 0 5px 50px 15px rgba(0, 0, 0, 0.2); }
@media only screen and (max-width: 767px) {
.header-area .is-sticky .oneMusic-main-menu {
        height: 70px; } }

.classy-navbar .nav-brand {
    max-width: 200px; }

@media only screen and (min-width: 768px) and (max-width: 991px) {
.breakpoint-on .classy-navbar .classy-menu {
        background-color: #000000; } }
@media only screen and (max-width: 767px) {
.breakpoint-on .classy-navbar .classy-menu {
        background-color: #000000; } }

@media only screen and (min-width: 768px) and (max-width: 991px) {
.classynav ul li .megamenu .single-mega.cn-col-4 {
        padding: 0; } }
@media only screen and (max-width: 767px) {
.classynav ul li .megamenu .single-mega.cn-col-4 {
        padding: 0; } }

.classycloseIcon .cross-wrap span {
    background: #ffffff; }

/* :: 5.0 Hero Slides Area */
.hero-area,
.hero-slides {
    position: relative;
    z-index: 1; }

.single-hero-slide {
    width: 100%;
    height: 950px;
    position: relative;
    z-index: 1;
    padding: 0 30px;
    overflow: hidden; }
@media only screen and (min-width: 992px) and (max-width: 1199px) {
.single-hero-slide {
        height: 700px; } }
@media only screen and (min-width: 768px) and (max-width: 991px) {
.single-hero-slide {
        height: 650px; } }
@media only screen and (max-width: 767px) {
.single-hero-slide {
        height: 500px; } }
.single-hero-slide::after {
    position: absolute;
    width: 100%;
    height: 100%;
    z-index: -5;
    top: 0;
    left: 0;
    background-color: rgba(0, 0, 0, 0.35);
    content: ''; }
.single-hero-slide .slide-img {
    position: absolute;
    width: 100%;
    height: 100%;
    z-index: -10;
    left: 0;
    right: 0;
    top: 0;
    bottom: 0; }
.single-hero-slide .hero-slides-content {
    display: inline-block;
    width: 100%; }
.single-hero-slide .hero-slides-content h6 {
    font-size: 18px;
    color: #fff;
    letter-spacing: 20px;
    text-transform: uppercase;
    margin-bottom: 20px;
    display: block; }
@media only screen and (max-width: 767px) {
.single-hero-slide .hero-slides-content h6 {
        letter-spacing: 5px; } }
.single-hero-slide .hero-slides-content h2 {
    position: relative;
    z-index: 1;
    font-size: 60px;
    color: #ffffff;
    margin-bottom: 0;
    font-weight: 400;
    display: block;
    text-transform: capitalize;
    letter-spacing: 30px;
    overflow: hidden; }
.single-hero-slide .hero-slides-content h2 span {
    position: absolute;
    top: 0;
    width: 100%;
    height: 100%;
    left: 0;
    color: rgba(255, 255, 255, 0.15);
    -webkit-animation: textsonar 6s linear infinite;
    animation: textsonar 6s linear infinite; }
@media only screen and (min-width: 768px) and (max-width: 991px) {
.single-hero-slide .hero-slides-content h2 {
        letter-spacing: 15px;
        font-size: 42px; } }
@media only screen and (max-width: 767px) {
.single-hero-slide .hero-slides-content h2 {
        letter-spacing: 5px;
        font-size: 30px; } }
.single-hero-slide .hero-slides-content .btn {
    border: 1px solid #fff;
    background-color: transparent;
    color: #fff; }
.single-hero-slide .hero-slides-content .btn:hover, .single-hero-slide .hero-slides-content .btn:focus {
    background-color: #fff;
    color: #000000; }

@-webkit-keyframes textsonar {
    0% {
    -webkit-transform: scaleX(1);
    transform: scaleX(1); }
    50% {
    -webkit-transform: scaleX(1.15);
    transform: scaleX(1.15); }
    100% {
    -webkit-transform: scaleX(1);
    transform: scaleX(1); } }
@keyframes textsonar {
    0% {
    -webkit-transform: scaleX(1);
    transform: scaleX(1); }
    50% {
    -webkit-transform: scaleX(1.15);
    transform: scaleX(1.15); }
    100% {
    -webkit-transform: scaleX(1);
    transform: scaleX(1); } }
.single-hero-slide .slide-img {
    -webkit-animation: slide 12s linear infinite;
    animation: slide 12s linear infinite; }

@-webkit-keyframes slide {
    0% {
    -webkit-transform: scale(1);
    transform: scale(1); }
    50% {
    -webkit-transform: scale(1.2);
    transform: scale(1.2); }
    100% {
    -webkit-transform: scale(1);
    transform: scale(1); } }
@keyframes slide {
    0% {
    -webkit-transform: scale(1);
    transform: scale(1); }
    50% {
    -webkit-transform: scale(1.2);
    transform: scale(1.2); }
    100% {
    -webkit-transform: scale(1);
    transform: scale(1); } }
/* :: 6.0 Buy Now Area CSS */
.oneMusic-buy-now-area.has-fluid {
    padding-left: 4%;
    padding-right: 4%;
    position: relative;
    z-index: 1; }

/* :: 15.0 Breadcumb Area CSS */
.breadcumb-area {
    position: relative;
    z-index: 10;
    width: 100%;
    height: 385px; }
@media only screen and (max-width: 767px) {
.breadcumb-area {
        height: 270px; } }
.breadcumb-area .bradcumbContent {
    position: absolute;
    background-color: rgba(0, 0, 0, 0);
    width: 552px;
    bottom: 125px;
    left: 50%;
    z-index: 100;
    text-align: center;
    padding-top: 40px;
    -webkit-transform: translateX(-50%);
    transform: translateX(-50%); }
@media only screen and (max-width: 767px) {
.breadcumb-area .bradcumbContent {
        width: calc(100% - 60px);
        padding-top: 30px; } }
.breadcumb-area .bradcumbContent p {
    line-height: 1.5;
    font-size: 16px;
    color:#b3b3b3;
    margin-top: 10px; }
.breadcumb-area .bradcumbContent h2 {
    font-size: 30px;
    color:#ffffff;
    letter-spacing: 10px;
    text-transform: uppercase;
    line-height: 1;
    margin-bottom: 0; }
@media only screen and (max-width: 767px) {
.breadcumb-area .bradcumbContent h2 {
        font-size: 18px;
        letter-spacing: 5px; } }

/*Info Area*/
.Info-wrapper {
    display: flex;
    justify-content: center;/*水平置中*/
    align-items: center; /*垂直置中*/
    height: 500px;
    font-family: 'Times New Roman', Times, serif;
}
.Info-wrapper .Info-container{
    border: #000000 1px solid;
    padding: 10px;
    padding-left: 30px;
    padding-right: 30px ;
}
.Info-wrapper .Info-container .Info-upper{
    padding: 20px;
}
.Info-wrapper .Info-container .Info-upper .book-Info{
    font-size: 22px;
    font-weight: 700;
}
.Info-wrapper .Info-container .Info-upper .book-Info-2{
    color: #b3b3b3;
}
.Info-wrapper .Info-buttom{
    display: flex;
    flex-direction: row;
    padding: 20px;}
.Info-wrapper .Info-buttom .Info-img{
    display: flex;
    justify-content: center;
    width: 250px;
    height: 250px;
    border: #000000 1px solid;
}
.Info-wrapper .Info-buttom img{
    height: 100%;
    max-width: 100%;
}
.Info-wrapper .Info-buttom .Info-content{
    padding-left: 50px;}
.Info-wrapper .Info-buttom .Info-content .Info-text-1{
    border-bottom:#AEB2BA 1px solid;}
.Info-wrapper .Info-buttom .Info-content .Info-order-area{
    display: flex;
    flex-direction: row;
    padding: 10px;
    margin-top:20px ;
    border:#AEB2BA 1px solid;
}
.Info-wrapper .Info-buttom .Info-content .book-name{
    font-size: 20px;
    font-weight: 700;
    font-family: 'Times New Roman', Times, serif;
    padding-bottom: 5px;
}

.Info-wrapper .Info-buttom .Info-content .price{
    font-size: 18px;
    font-weight: 700;
    color: #0000FF;
    font-family: 'Times New Roman', Times, serif;
    padding-bottom: 5px;
}

.Info-wrapper .Info-buttom .Info-content .Info-text-2{
    padding-top: 10px;
}

.Info-wrapper .Info-buttom .Info-content .Info-order-area{
    margin-top: 20px;
    padding: 20px;
}
.Info-wrapper .Info-buttom .Info-content .Info-order-area button{
    margin-right: 20px;
    color: #0000FF;
    border: #0000FF 1px solid;
    transition: 2s;
}
.Info-wrapper .Info-buttom .Info-content .Info-order-area button:hover {
    color:#ffffff;
    /*background-color: #0000FF;*/
    box-shadow:  0 200px #0000FF inset;
}

/*tab Area*/
[data-tab-content]{
    display: none;
}

.active[data-tab-content]{
    display: block;
}

.tabs{
    display: flex;
    flex-direction: row;
    /*justify-content: space-around;*/
    list-style-type: none;
    margin: 75px;
    margin-left: 150px;
    margin-right: 150px;
    border-bottom: #5f5f5f 1px solid;
}

.tab{
    cursor: pointer;
    padding: 10px;
    padding-bottom: 7px;
    margin-right: 30px;
    border-radius: 5% 5% 0% 0%;
}

.tab.active{
    /*background-color: #d6d6d6;*/
    border-bottom: #0000FF 3px solid;
}

.tab:hover{
    background-color: rgba(0, 13, 255, 0.2);
}

.tab-content{
    display: flex;
    /*justify-content: center;*/
    padding-left: 150px;
    padding-right: 150px;
}


/* ====== The End ====== */

/*# sourceMappingURL=style.css.map */