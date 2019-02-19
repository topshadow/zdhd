import { Component } from "@angular/core";
import * as AspNetData from "devextreme-aspnet-data-nojquery";
import { environment } from 'src/environments/environment';


@Component({ selector: "product-tag", templateUrl:"./product-tag-page.component.html" })
export class ProductTagPageComponent {
  productTagUrl = environment.ip + "/api/Product/ProductTag";
  productTagDataSource = AspNetData.createStore({
    key:"productTagId",
    loadUrl: this.productTagUrl,
    insertUrl: this.productTagUrl,
    deleteUrl: this.productTagUrl,
    updateUrl: this.productTagUrl
  })

}
