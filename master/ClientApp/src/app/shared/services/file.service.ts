import { Injectable } from '@angular/core';

@Injectable()
export class FileService{

  selectImage(): Promise<string>{
    return new Promise(resolve => {
      var inputEl = document.createElement("input");
      inputEl.type = "file";
      inputEl.onchange = function (e) {
        var reader = new FileReader();
        reader.onload = function (data) {
          resolve(data.target["result"]);
        }
        reader.readAsDataURL(inputEl.files[0]);

      }
      inputEl.click();
    });
    
  }
}
