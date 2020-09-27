//
// File generated by HDevelop for HALCON/.NET (C#) Version 18.11.0.1
// Non-ASCII strings in this file are encoded in UTF-8.
// 
// Please note that non-ASCII characters in string constants are exported
// as octal codes in order to guarantee that the strings are correctly
// created on all systems, independent on any compiler settings.
// 
// Source files with different encoding should not be mixed in one project.
//
//  This file is intended to be used with the HDevelopTemplate or
//  HDevelopTemplateWPF projects located under %HALCONEXAMPLES%\c#

using System;
using HalconDotNet;

public partial class HDevelopExport
{
  public HTuple hv_ExpDefaultWinHandle;

  // Main procedure 
  private void action()
  {


    // Local iconic variables 

    HObject ho_ProfileImageTLW=null, ho_ProfileImageBW=null;

    // Local control variables 

    HTuple hv_ImageFilesTL = new HTuple(), hv_ImageFilesBW = new HTuple();
    HTuple hv_Index = new HTuple();
    // Initialize local and output iconic variables 
    HOperatorSet.GenEmptyObj(out ho_ProfileImageTLW);
    HOperatorSet.GenEmptyObj(out ho_ProfileImageBW);
    hv_ImageFilesTL.Dispose();
    HOperatorSet.ListFiles("E:/image/MVS/0923/1", (new HTuple("files")).TupleConcat(
        "follow_links"), out hv_ImageFilesTL);
    {
    HTuple ExpTmpOutVar_0;
    HOperatorSet.TupleRegexpSelect(hv_ImageFilesTL, (new HTuple("\\.(tif|tiff|gif|bmp|jpg|jpeg|jp2|png|pcx|pgm|ppm|pbm|xwd|ima|hobj)$")).TupleConcat(
        "ignore_case"), out ExpTmpOutVar_0);
    hv_ImageFilesTL.Dispose();
    hv_ImageFilesTL = ExpTmpOutVar_0;
    }
    hv_ImageFilesBW.Dispose();
    HOperatorSet.ListFiles("E:/image/MVS/0923/2", (new HTuple("files")).TupleConcat(
        "follow_links"), out hv_ImageFilesBW);
    {
    HTuple ExpTmpOutVar_0;
    HOperatorSet.TupleRegexpSelect(hv_ImageFilesBW, (new HTuple("\\.(tif|tiff|gif|bmp|jpg|jpeg|jp2|png|pcx|pgm|ppm|pbm|xwd|ima|hobj)$")).TupleConcat(
        "ignore_case"), out ExpTmpOutVar_0);
    hv_ImageFilesBW.Dispose();
    hv_ImageFilesBW = ExpTmpOutVar_0;
    }

    for (hv_Index=0; (int)hv_Index<=(int)((new HTuple(hv_ImageFilesTL.TupleLength()
        ))-1); hv_Index = (int)hv_Index + 1)
    {
      using (HDevDisposeHelper dh = new HDevDisposeHelper())
      {
      ho_ProfileImageTLW.Dispose();
      HOperatorSet.ReadImage(out ho_ProfileImageTLW, hv_ImageFilesTL.TupleSelect(
          hv_Index));
      }
      //Image Acquisition 01: Do something
      using (HDevDisposeHelper dh = new HDevDisposeHelper())
      {
      ho_ProfileImageBW.Dispose();
      HOperatorSet.ReadImage(out ho_ProfileImageBW, hv_ImageFilesTL.TupleSelect(hv_Index));
      }
    }

    ho_ProfileImageTLW.Dispose();
    ho_ProfileImageBW.Dispose();

    hv_ImageFilesTL.Dispose();
    hv_ImageFilesBW.Dispose();
    hv_Index.Dispose();

  }

  public void InitHalcon()
  {
    // Default settings used in HDevelop
    HOperatorSet.SetSystem("width", 512);
    HOperatorSet.SetSystem("height", 512);
  }

  public void RunHalcon(HTuple Window)
  {
    hv_ExpDefaultWinHandle = Window;
    action();
  }

}

