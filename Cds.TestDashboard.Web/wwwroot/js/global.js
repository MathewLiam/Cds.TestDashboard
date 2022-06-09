/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ({

/***/ "./Cds.TestDashboard.Web/UI/ts/modules/sidebar/index.ts":
/*!**************************************************************!*\
  !*** ./Cds.TestDashboard.Web/UI/ts/modules/sidebar/index.ts ***!
  \**************************************************************/
/***/ ((__unused_webpack_module, exports) => {

eval("\r\nObject.defineProperty(exports, \"__esModule\", ({ value: true }));\r\nclass SideBar {\r\n    constructor(_element) {\r\n        this.sidebarElement = _element;\r\n        this.sidebarLinks = _element.querySelectorAll('a');\r\n        this.setActiveTab();\r\n    }\r\n    setActiveTab() {\r\n        console.log(this.sidebarLinks);\r\n        Array.from(this.sidebarLinks).forEach((link) => {\r\n            if (link.href == window.location.href || window.location.href.includes(link.href) && !this.activeLink) {\r\n                link.classList.toggle('active', true);\r\n                this.activeLink = link;\r\n            }\r\n        });\r\n    }\r\n}\r\nexports[\"default\"] = SideBar;\r\n\n\n//# sourceURL=webpack://cds.test.dashboard/./Cds.TestDashboard.Web/UI/ts/modules/sidebar/index.ts?");

/***/ }),

/***/ "./Cds.TestDashboard.Web/UI/ts/root/global.ts":
/*!****************************************************!*\
  !*** ./Cds.TestDashboard.Web/UI/ts/root/global.ts ***!
  \****************************************************/
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {

eval("\r\nvar __importDefault = (this && this.__importDefault) || function (mod) {\r\n    return (mod && mod.__esModule) ? mod : { \"default\": mod };\r\n};\r\nObject.defineProperty(exports, \"__esModule\", ({ value: true }));\r\nconst sidebar_1 = __importDefault(__webpack_require__(/*! @modules/sidebar */ \"./Cds.TestDashboard.Web/UI/ts/modules/sidebar/index.ts\"));\r\nlet sidebarElements = document.getElementsByClassName('sidebar');\r\nif (sidebarElements) {\r\n    let sidebar = Array.from(sidebarElements)[0];\r\n    new sidebar_1.default(sidebar);\r\n}\r\n\n\n//# sourceURL=webpack://cds.test.dashboard/./Cds.TestDashboard.Web/UI/ts/root/global.ts?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module is referenced by other modules so it can't be inlined
/******/ 	var __webpack_exports__ = __webpack_require__("./Cds.TestDashboard.Web/UI/ts/root/global.ts");
/******/ 	
/******/ })()
;