"use strict";(self.webpackChunkclient=self.webpackChunkclient||[]).push([[207],{9207:(C,u,o)=>{o.r(u),o.d(u,{BasketModule:()=>g});var r=o(4755),c=o(8304),t=o(9523),d=o(5866),l=o(5053),p=o(8795);function k(e,a){1&e&&(t.TgZ(0,"div")(1,"p"),t._uU(2,"Threre are no items in your basket"),t.qZA()())}function v(e,a){if(1&e){const n=t.EpF();t.ynx(0),t.TgZ(1,"div",0)(2,"div",2)(3,"app-basket-summary",3),t.NdJ("addItem",function(m){t.CHM(n);const i=t.oxw();return t.KtG(i.incrementQuantity(m))})("removeItem",function(m){t.CHM(n);const i=t.oxw();return t.KtG(i.removeItem(m))}),t.qZA()(),t.TgZ(4,"div",2)(5,"div",4),t._UZ(6,"app-order-totals"),t.TgZ(7,"div",5)(8,"a",6),t._uU(9," Proceed to checkout "),t.qZA()()()()(),t.BQk()}}const B=[{path:"",component:(()=>{class e{constructor(n){this.basketService=n}incrementQuantity(n){this.basketService.addItemToBasket(n)}removeItem(n){this.basketService.removeItemFromBasket(n.id,n.quantity)}}return e.\u0275fac=function(n){return new(n||e)(t.Y36(d.v))},e.\u0275cmp=t.Xpm({type:e,selectors:[["app-basket"]],decls:5,vars:6,consts:[[1,"container"],[4,"ngIf"],[1,"row"],[3,"addItem","removeItem"],[1,"col-6","offset-6"],[1,"d-grid"],["routerLink","/checkout",1,"btn","btn-outline-primary","pu-2"]],template:function(n,s){1&n&&(t.TgZ(0,"div",0),t.YNc(1,k,3,0,"div",1),t.ALo(2,"async"),t.YNc(3,v,10,0,"ng-container",1),t.ALo(4,"async"),t.qZA()),2&n&&(t.xp6(1),t.Q6J("ngIf",null===t.lcZ(2,2,s.basketService.basketSource$)),t.xp6(2),t.Q6J("ngIf",t.lcZ(4,4,s.basketService.basketSource$)))},dependencies:[r.O5,c.rH,l.S,p.b,r.Ov]}),e})()}];let f=(()=>{class e{}return e.\u0275fac=function(n){return new(n||e)},e.\u0275mod=t.oAB({type:e}),e.\u0275inj=t.cJS({imports:[c.Bz.forChild(B),c.Bz]}),e})();var y=o(4466);let g=(()=>{class e{}return e.\u0275fac=function(n){return new(n||e)},e.\u0275mod=t.oAB({type:e}),e.\u0275inj=t.cJS({imports:[r.ez,f,y.m]}),e})()}}]);