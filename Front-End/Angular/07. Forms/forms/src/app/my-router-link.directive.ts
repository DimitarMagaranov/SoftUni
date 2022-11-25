import { Directive, ElementRef, Input, OnDestroy, OnInit, Optional, Renderer2, TemplateRef, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appMyRouterLink]'
})
export class MyRouterLinkDirective implements OnInit, OnDestroy {

  @Input() appMyRouterLink!: string;
  @Input() template!: TemplateRef<any>;

  unsubs: (() => void)[] = [];

  viewHasBeenCreated = false;

  constructor(
    private elRef: ElementRef,
    private renderer: Renderer2,
    private vc: ViewContainerRef) { 
    // this.renderer.setAttribute(this.elRef.nativeElement, 'data-test', '123');
    // this.renderer.appendChild(this.elRef.nativeElement, this.renderer.createElement('p'));
  
    this.unsubs.push(this.renderer.listen(this.elRef.nativeElement, 'mouseover', this.mouseOverHandler));
    this.unsubs.push(this.renderer.listen(this.elRef.nativeElement, 'mouseleave', this.mouseLeaveHandler));
  }
  ngOnInit(): void {
    console.log(this.appMyRouterLink, this.template);
    
  }
  ngOnDestroy(): void {
    this.unsubs.forEach(fn => fn());
  }

  mouseOverHandler = (e: MouseEvent): void => {
    // this.renderer.setStyle(this.elRef.nativeElement, 'color', 'red');
    if(this.viewHasBeenCreated) { return; }
    this.vc.createEmbeddedView(this.template);
    this.viewHasBeenCreated = true;
  }

  mouseLeaveHandler = (e: MouseEvent): void => {
    // this.renderer.setStyle(this.elRef.nativeElement, 'color', 'initial');
    // this.renderer.removeAttribute(this.elRef.nativeElement, 'style');
    // this.renderer.removeStyle(this.elRef.nativeElement, 'color');
    this.vc.clear();
    this.viewHasBeenCreated = false;
  }
}
