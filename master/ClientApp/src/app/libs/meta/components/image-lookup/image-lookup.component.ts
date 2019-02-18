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
  @Input() keyExpr: string = "url";
  async addImage() {
    let base64 = await this.fileService.selectImage();
    if (!this.value) this.value = [];
    let res: any = await this.uploadService.uploadImage(base64).toPromise();
    if (res.ok) {
      var obj = {};
      obj[this.keyExpr] = res.url;
      this.value.push(obj);
    } else { }

    this.valueChange.emit(this.value);



  }

  constructor(private uploadService: UploadService, private fileService: FileService) { }
}
