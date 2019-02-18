import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable()
export class UploadService{
  static readonly uploadImageUrl = environment.ip+"/api/Common/Upload/uploadImage"

  uploadImage(base64: string) {
    return this.httpClient.post(UploadService.uploadImageUrl, { base64 });
  }
  constructor(private httpClient: HttpClient) {
    
  }
}
