import { Component,EventEmitter, Input, OnInit, Output } from '@angular/core';
import {WindowCustom} from '../../Models/WindowCustom';
/**
 * Generated class for the WindowScreenComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'window-screen',
  templateUrl: 'window-screen.html'
})
export class WindowScreenComponent {

  @Input()
  windowInput: Array<WindowCustom> = new Array<WindowCustom>();

  constructor() {
    console.log('Hello WindowScreenComponent Component');
  }

}
