import { Component } from '@angular/core';
import * as AspNetData from "devextreme-aspnet-data-nojquery";
import { environment } from 'src/environments/environment';
@Component({ selector: "product-page", templateUrl:"./product-page.component.html" })
export class ProductPageComponent {
  productUrl = environment.ip+"/api/Product/Product"
  productDataSource = AspNetData.createStore({
    loadUrl: this.productUrl,
    insertUrl: this.productUrl,
    updateUrl: this.productUrl,
    deleteUrl: this.productUrl
  });
}
