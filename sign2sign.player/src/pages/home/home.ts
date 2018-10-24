import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

   windows = [{name:"win1", x:0, y:0, width:"30" ,height:"20", style:''},{name:"win2", x:500, y:0, width:"40" ,height:"50", style:''}]
  

  constructor(public navCtrl: NavController) {

    this.windows.forEach(e => {
      e.style = `width: ${e.width}px; height:100px`;
      e.width = e.width + "%";
      e.height = e.height + "%";
    
    });

  }

}
