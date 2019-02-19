import { NgModule, ModuleWithProviders } from '@angular/core';
import { DxDataGridModule, DxTreeListModule, DxPopupModule, DxSwitchModule, DxButtonModule, DxToolbarModule, DxHtmlEditorModule } from 'devextreme-angular';
import { CommonModule } from '@angular/common';
import { DxiRowModule } from 'devextreme-angular/ui/nested/row-dxi';
import { DxiColModule } from 'devextreme-angular/ui/nested/col-dxi';
import { UploadService } from './services/upload.service';
import { FileService } from './services/file.service';

@NgModule({

  imports: [CommonModule,
    DxDataGridModule, DxTreeListModule,
    DxPopupModule, DxSwitchModule, DxButtonModule,
    DxiRowModule, DxiColModule, DxToolbarModule, DxHtmlEditorModule,
  ],
  exports: [DxDataGridModule, DxTreeListModule,
    DxPopupModule, DxSwitchModule, DxButtonModule, CommonModule,
    DxiRowModule, DxiColModule, DxToolbarModule, DxHtmlEditorModule,],
  providers: [UploadService, FileService]
})
export class SharedModule {

  public static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [UploadService]
    }
  }
}
