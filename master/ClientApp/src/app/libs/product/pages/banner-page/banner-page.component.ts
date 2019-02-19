import { Component } from '@angular/core';
import * as AspNetData from "devextreme-aspnet-data-nojquery";
import { environment } from 'src/environments/environment';
import { ModeEnum } from 'src/app/libs/meta/enums/Mode.enum';
@Component({ selector: "banner-page", templateUrl:"./banner-page.component.html" })
export class BannerPageComponent {
  ModeEnum = ModeEnum

  bannerUrl = environment.ip + "/api/Product/Banner"
  bannerDataSource = AspNetData.createStore({
    key: "bannerId",
    loadUrl: this.bannerUrl,
    insertUrl: this.bannerUrl,
    updateUrl: this.bannerUrl,
    deleteUrl: this.bannerUrl
  });

  productUrl = environment.ip + "/api/Product/Product";
  productDataSource = AspNetData.createStore({
    loadUrl: this.productUrl,
    insertUrl: this.productUrl,
    updateUrl: this.productUrl,
    deleteUrl: this.productUrl
  });
}
