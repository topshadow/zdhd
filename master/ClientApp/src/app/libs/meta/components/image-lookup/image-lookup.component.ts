import { Component, Input, EventEmitter, Output } from '@angular/core';
import { ModeEnum } from '../../enums/Mode.enum';
import { UploadService } from 'src/app/shared/services/upload.service';
import { FileService } from 'src/app/shared/services/file.service';

@Component({ selector: "image-lookup", templateUrl: "./image-lookup.component.html" })
export class ImageLookupComponent {
  @Input() value = [];
  @Output() valueChange = new EventEmitter();
  @Input() isMultity: boolean = true;
  @Input() mode: ModeEnum = ModeEnum.Query;
  ModeEnum = ModeEnum
  @Input() keyExpr: string = "";
  async addImage() {
    let base64 = await this.fileService.selectImage();
    if (!this.value) this.value = [];
    let res: any = await this.uploadService.uploadImage(base64).toPromise();
    if (res.ok) {
      if (this.keyExpr) {
        var obj = {};
        obj[this.keyExpr] = res.url;
        if (this.isMultity) {
          this.value.push(obj);
        } else {
          this.value = obj as any;
        }
      } else {
        
        this.value = res.url;
      }
      this.valueChange.emit(this.value);
    } else { }
  }

  constructor(private uploadService: UploadService, private fileService: FileService) { }
}
