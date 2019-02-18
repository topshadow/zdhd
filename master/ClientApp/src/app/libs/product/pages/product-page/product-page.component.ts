import { Component } from '@angular/core';
import * as AspNetData from "devextreme-aspnet-data-nojquery";
import { environment } from 'src/environments/environment';
import { ModeEnum } from 'src/app/libs/meta/enums/Mode.enum';
@Component({ selector: "product-page", templateUrl:"./product-page.component.html" })
export class ProductPageComponent {
  subProductsEditPopVisible: boolean = false;
  subProductsPopVisible: boolean = false;
  ModeEnum = ModeEnum;
  productUrl = environment.ip+"/api/Product/Product"
  productDataSource = AspNetData.createStore({
    key:"productId",
    loadUrl: this.productUrl,
    insertUrl: this.productUrl,
    updateUrl: this.productUrl,
    deleteUrl: this.productUrl
  });
}
