import { Component } from '@angular/core';
import { RecordService } from 'src/app/services/intranet/record.service';

@Component({
  selector: 'app-marketing-web',
  templateUrl: './marketing-web.component.html',
  styleUrls: ['./marketing-web.component.scss']
})
export class MarketingWebComponent {
  title = "PR&MKTNG"
  description = "Aliqua non nulla ad non consequat deserunt dolore Lorem consequat ipsum aliqua. Nostrud irure dolore do ut in officia veniam incididunt culpa irure commodo consectetur tempor. Nisi ex consectetur deserunt culpa magna est nostrud ut do nisi anim duis exercitation. Nulla dolor qui ullamco reprehenderit dolor minim ut ad do aute esse in laboris commodo. Tempor adipisicing laboris sunt dolore excepteur amet culpa veniam ex fugiat dolore irure. Eu eu ad adipisicing et sunt. Cupidatat nulla est veniam sunt amet duis."
  records: Array<any> = new Array<any>();
  buttonTitle : string = "Ver web"

  constructor(
    private _recordService : RecordService
  ){}
  ngOnInit(){
    this.getRecords()
  }

  getRecords() {
    this._recordService.get().subscribe((res) => {
      let records = new Array();
      res.forEach((val) => {
        records.push(val);
      });
      this.records = [...records];
    });
  }
}
