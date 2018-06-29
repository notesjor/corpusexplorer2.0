using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  internal class udpipe_csharpPINVOKE
  {
    protected static SWIGExceptionHelper swigExceptionHelper = new SWIGExceptionHelper();

    protected static SWIGStringHelper swigStringHelper = new SWIGStringHelper();


    static udpipe_csharpPINVOKE()
    {
    }

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_Add")]
    public static extern void Children_Add(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_AddRange")]
    public static extern void Children_AddRange(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_capacity")]
    public static extern uint Children_capacity(HandleRef jarg1);


    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_Clear")]
    public static extern void Children_Clear(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_Contains")]
    public static extern bool Children_Contains(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_getitem")]
    public static extern int Children_getitem(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_getitemcopy")]
    public static extern int Children_getitemcopy(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_GetRange")]
    public static extern IntPtr Children_GetRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_IndexOf")]
    public static extern int Children_IndexOf(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_Insert")]
    public static extern void Children_Insert(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_InsertRange")]
    public static extern void Children_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_LastIndexOf")]
    public static extern int Children_LastIndexOf(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_Remove")]
    public static extern bool Children_Remove(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_RemoveAt")]
    public static extern void Children_RemoveAt(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_RemoveRange")]
    public static extern void Children_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_Repeat")]
    public static extern IntPtr Children_Repeat(int jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_reserve")]
    public static extern void Children_reserve(HandleRef jarg1, uint jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_Reverse__SWIG_0")]
    public static extern void Children_Reverse__SWIG_0(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_Reverse__SWIG_1")]
    public static extern void Children_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_setitem")]
    public static extern void Children_setitem(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_SetRange")]
    public static extern void Children_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Children_size")]
    public static extern uint Children_size(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_Add")]
    public static extern void Comments_Add(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_AddRange")]
    public static extern void Comments_AddRange(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_capacity")]
    public static extern uint Comments_capacity(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_Clear")]
    public static extern void Comments_Clear(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_Contains")]
    public static extern bool Comments_Contains(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_getitem")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Comments_getitem(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_getitemcopy")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Comments_getitemcopy(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_GetRange")]
    public static extern IntPtr Comments_GetRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_IndexOf")]
    public static extern int Comments_IndexOf(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_Insert")]
    public static extern void Comments_Insert(HandleRef jarg1, int jarg2,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_InsertRange")]
    public static extern void Comments_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_LastIndexOf")]
    public static extern int Comments_LastIndexOf(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_Remove")]
    public static extern bool Comments_Remove(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_RemoveAt")]
    public static extern void Comments_RemoveAt(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_RemoveRange")]
    public static extern void Comments_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_Repeat")]
    public static extern IntPtr Comments_Repeat(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_reserve")]
    public static extern void Comments_reserve(HandleRef jarg1, uint jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_Reverse__SWIG_0")]
    public static extern void Comments_Reverse__SWIG_0(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_Reverse__SWIG_1")]
    public static extern void Comments_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_setitem")]
    public static extern void Comments_setitem(HandleRef jarg1, int jarg2,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_SetRange")]
    public static extern void Comments_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Comments_size")]
    public static extern uint Comments_size(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_Children")]
    public static extern void delete_Children(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_Comments")]
    public static extern void delete_Comments(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_EmptyNode")]
    public static extern void delete_EmptyNode(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_EmptyNodes")]
    public static extern void delete_EmptyNodes(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_Evaluator")]
    public static extern void delete_Evaluator(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_InputFormat")]
    public static extern void delete_InputFormat(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_Model")]
    public static extern void delete_Model(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_MultiwordToken")]
    public static extern void delete_MultiwordToken(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_MultiwordTokens")]
    public static extern void delete_MultiwordTokens(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_OutputFormat")]
    public static extern void delete_OutputFormat(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_Pipeline")]
    public static extern void delete_Pipeline(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_ProcessingError")]
    public static extern void delete_ProcessingError(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_Sentence")]
    public static extern void delete_Sentence(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_Sentences")]
    public static extern void delete_Sentences(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_Token")]
    public static extern void delete_Token(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_Trainer")]
    public static extern void delete_Trainer(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_Version")]
    public static extern void delete_Version(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_Word")]
    public static extern void delete_Word(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_delete_Words")]
    public static extern void delete_Words(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_deps_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string EmptyNode_deps_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_deps_set")]
    public static extern void EmptyNode_deps_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_feats_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string EmptyNode_feats_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_feats_set")]
    public static extern void EmptyNode_feats_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_form_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string EmptyNode_form_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_form_set")]
    public static extern void EmptyNode_form_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_id_get")]
    public static extern int EmptyNode_id_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_id_set")]
    public static extern void EmptyNode_id_set(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_index_get")]
    public static extern int EmptyNode_index_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_index_set")]
    public static extern void EmptyNode_index_set(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_lemma_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string EmptyNode_lemma_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_lemma_set")]
    public static extern void EmptyNode_lemma_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_misc_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string EmptyNode_misc_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_misc_set")]
    public static extern void EmptyNode_misc_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_upostag_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string EmptyNode_upostag_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_upostag_set")]
    public static extern void EmptyNode_upostag_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_xpostag_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string EmptyNode_xpostag_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNode_xpostag_set")]
    public static extern void EmptyNode_xpostag_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_Add")]
    public static extern void EmptyNodes_Add(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_AddRange")]
    public static extern void EmptyNodes_AddRange(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_capacity")]
    public static extern uint EmptyNodes_capacity(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_Clear")]
    public static extern void EmptyNodes_Clear(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_getitem")]
    public static extern IntPtr EmptyNodes_getitem(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_getitemcopy")]
    public static extern IntPtr EmptyNodes_getitemcopy(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_GetRange")]
    public static extern IntPtr EmptyNodes_GetRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_Insert")]
    public static extern void EmptyNodes_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_InsertRange")]
    public static extern void EmptyNodes_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_RemoveAt")]
    public static extern void EmptyNodes_RemoveAt(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_RemoveRange")]
    public static extern void EmptyNodes_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_Repeat")]
    public static extern IntPtr EmptyNodes_Repeat(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_reserve")]
    public static extern void EmptyNodes_reserve(HandleRef jarg1, uint jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_Reverse__SWIG_0")]
    public static extern void EmptyNodes_Reverse__SWIG_0(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_Reverse__SWIG_1")]
    public static extern void EmptyNodes_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_setitem")]
    public static extern void EmptyNodes_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_SetRange")]
    public static extern void EmptyNodes_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_EmptyNodes_size")]
    public static extern uint EmptyNodes_size(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Evaluator_DEFAULT_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Evaluator_DEFAULT_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Evaluator_evaluate__SWIG_0")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Evaluator_evaluate__SWIG_0(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Evaluator_evaluate__SWIG_1")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Evaluator_evaluate__SWIG_1(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Evaluator_NONE_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Evaluator_NONE_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Evaluator_setModel")]
    public static extern void Evaluator_setModel(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Evaluator_setParser")]
    public static extern void Evaluator_setParser(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Evaluator_setTagger")]
    public static extern void Evaluator_setTagger(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Evaluator_setTokenizer")]
    public static extern void Evaluator_setTokenizer(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_CONLLU_V1_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string InputFormat_CONLLU_V1_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_CONLLU_V2_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string InputFormat_CONLLU_V2_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_GENERIC_TOKENIZER_NORMALIZED_SPACES_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string InputFormat_GENERIC_TOKENIZER_NORMALIZED_SPACES_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_GENERIC_TOKENIZER_PRESEGMENTED_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string InputFormat_GENERIC_TOKENIZER_PRESEGMENTED_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_GENERIC_TOKENIZER_RANGES_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string InputFormat_GENERIC_TOKENIZER_RANGES_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_newConlluInputFormat__SWIG_0")]
    public static extern IntPtr InputFormat_newConlluInputFormat__SWIG_0(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_newConlluInputFormat__SWIG_1")]
    public static extern IntPtr InputFormat_newConlluInputFormat__SWIG_1();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_newGenericTokenizerInputFormat__SWIG_0")]
    public static extern IntPtr InputFormat_newGenericTokenizerInputFormat__SWIG_0(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_newGenericTokenizerInputFormat__SWIG_1")]
    public static extern IntPtr InputFormat_newGenericTokenizerInputFormat__SWIG_1();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_newHorizontalInputFormat__SWIG_0")]
    public static extern IntPtr InputFormat_newHorizontalInputFormat__SWIG_0(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_newHorizontalInputFormat__SWIG_1")]
    public static extern IntPtr InputFormat_newHorizontalInputFormat__SWIG_1();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_newInputFormat")]
    public static extern IntPtr InputFormat_newInputFormat(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_newPresegmentedTokenizer")]
    public static extern IntPtr InputFormat_newPresegmentedTokenizer(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_newVerticalInputFormat__SWIG_0")]
    public static extern IntPtr InputFormat_newVerticalInputFormat__SWIG_0(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_newVerticalInputFormat__SWIG_1")]
    public static extern IntPtr InputFormat_newVerticalInputFormat__SWIG_1();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_nextSentence__SWIG_0")]
    public static extern bool InputFormat_nextSentence__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_nextSentence__SWIG_1")]
    public static extern bool InputFormat_nextSentence__SWIG_1(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_resetDocument__SWIG_0")]
    public static extern void InputFormat_resetDocument__SWIG_0(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_resetDocument__SWIG_1")]
    public static extern void InputFormat_resetDocument__SWIG_1(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_InputFormat_setText")]
    public static extern void InputFormat_setText(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Model_DEFAULT_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Model_DEFAULT_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Model_load")]
    public static extern IntPtr Model_load(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Model_newTokenizer")]
    public static extern IntPtr Model_newTokenizer(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Model_parse__SWIG_0")]
    public static extern bool Model_parse__SWIG_0(HandleRef jarg1, HandleRef jarg2,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg3, HandleRef jarg4);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Model_parse__SWIG_1")]
    public static extern bool Model_parse__SWIG_1(HandleRef jarg1, HandleRef jarg2,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Model_tag__SWIG_0")]
    public static extern bool Model_tag__SWIG_0(HandleRef jarg1, HandleRef jarg2,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg3, HandleRef jarg4);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Model_tag__SWIG_1")]
    public static extern bool Model_tag__SWIG_1(HandleRef jarg1, HandleRef jarg2,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Model_TOKENIZER_NORMALIZED_SPACES_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Model_TOKENIZER_NORMALIZED_SPACES_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Model_TOKENIZER_PRESEGMENTED_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Model_TOKENIZER_PRESEGMENTED_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Model_TOKENIZER_RANGES_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Model_TOKENIZER_RANGES_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordToken_idFirst_get")]
    public static extern int MultiwordToken_idFirst_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordToken_idFirst_set")]
    public static extern void MultiwordToken_idFirst_set(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordToken_idLast_get")]
    public static extern int MultiwordToken_idLast_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordToken_idLast_set")]
    public static extern void MultiwordToken_idLast_set(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordToken_SWIGUpcast")]
    public static extern IntPtr MultiwordToken_SWIGUpcast(IntPtr jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_Add")]
    public static extern void MultiwordTokens_Add(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_AddRange")]
    public static extern void MultiwordTokens_AddRange(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_capacity")]
    public static extern uint MultiwordTokens_capacity(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_Clear")]
    public static extern void MultiwordTokens_Clear(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_getitem")]
    public static extern IntPtr MultiwordTokens_getitem(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_getitemcopy")]
    public static extern IntPtr MultiwordTokens_getitemcopy(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_GetRange")]
    public static extern IntPtr MultiwordTokens_GetRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_Insert")]
    public static extern void MultiwordTokens_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_InsertRange")]
    public static extern void MultiwordTokens_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_RemoveAt")]
    public static extern void MultiwordTokens_RemoveAt(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_RemoveRange")]
    public static extern void MultiwordTokens_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_Repeat")]
    public static extern IntPtr MultiwordTokens_Repeat(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_reserve")]
    public static extern void MultiwordTokens_reserve(HandleRef jarg1, uint jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_Reverse__SWIG_0")]
    public static extern void MultiwordTokens_Reverse__SWIG_0(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_Reverse__SWIG_1")]
    public static extern void MultiwordTokens_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_setitem")]
    public static extern void MultiwordTokens_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_SetRange")]
    public static extern void MultiwordTokens_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_MultiwordTokens_size")]
    public static extern uint MultiwordTokens_size(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Children__SWIG_0")]
    public static extern IntPtr new_Children__SWIG_0();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Children__SWIG_1")]
    public static extern IntPtr new_Children__SWIG_1(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Children__SWIG_2")]
    public static extern IntPtr new_Children__SWIG_2(int jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Comments__SWIG_0")]
    public static extern IntPtr new_Comments__SWIG_0();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Comments__SWIG_1")]
    public static extern IntPtr new_Comments__SWIG_1(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Comments__SWIG_2")]
    public static extern IntPtr new_Comments__SWIG_2(int jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_EmptyNode__SWIG_0")]
    public static extern IntPtr new_EmptyNode__SWIG_0(int jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_EmptyNode__SWIG_1")]
    public static extern IntPtr new_EmptyNode__SWIG_1(int jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_EmptyNode__SWIG_2")]
    public static extern IntPtr new_EmptyNode__SWIG_2();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_EmptyNodes__SWIG_0")]
    public static extern IntPtr new_EmptyNodes__SWIG_0();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_EmptyNodes__SWIG_1")]
    public static extern IntPtr new_EmptyNodes__SWIG_1(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_EmptyNodes__SWIG_2")]
    public static extern IntPtr new_EmptyNodes__SWIG_2(int jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Evaluator")]
    public static extern IntPtr new_Evaluator(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg3, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg4);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_MultiwordToken__SWIG_0")]
    public static extern IntPtr new_MultiwordToken__SWIG_0(int jarg1, int jarg2,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg3, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg4);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_MultiwordToken__SWIG_1")]
    public static extern IntPtr new_MultiwordToken__SWIG_1(int jarg1, int jarg2,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_MultiwordToken__SWIG_2")]
    public static extern IntPtr new_MultiwordToken__SWIG_2(int jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_MultiwordToken__SWIG_3")]
    public static extern IntPtr new_MultiwordToken__SWIG_3(int jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_MultiwordToken__SWIG_4")]
    public static extern IntPtr new_MultiwordToken__SWIG_4();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_MultiwordTokens__SWIG_0")]
    public static extern IntPtr new_MultiwordTokens__SWIG_0();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_MultiwordTokens__SWIG_1")]
    public static extern IntPtr new_MultiwordTokens__SWIG_1(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_MultiwordTokens__SWIG_2")]
    public static extern IntPtr new_MultiwordTokens__SWIG_2(int jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Pipeline")]
    public static extern IntPtr new_Pipeline(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg3, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg4, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg5);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_ProcessingError")]
    public static extern IntPtr new_ProcessingError();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Sentence")]
    public static extern IntPtr new_Sentence();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Sentences__SWIG_0")]
    public static extern IntPtr new_Sentences__SWIG_0();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Sentences__SWIG_1")]
    public static extern IntPtr new_Sentences__SWIG_1(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Sentences__SWIG_2")]
    public static extern IntPtr new_Sentences__SWIG_2(int jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Token__SWIG_0")]
    public static extern IntPtr new_Token__SWIG_0(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Token__SWIG_1")]
    public static extern IntPtr new_Token__SWIG_1(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Token__SWIG_2")]
    public static extern IntPtr new_Token__SWIG_2();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Trainer")]
    public static extern IntPtr new_Trainer();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Version")]
    public static extern IntPtr new_Version();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Word__SWIG_0")]
    public static extern IntPtr new_Word__SWIG_0(int jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Word__SWIG_1")]
    public static extern IntPtr new_Word__SWIG_1(int jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Word__SWIG_2")]
    public static extern IntPtr new_Word__SWIG_2();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Words__SWIG_0")]
    public static extern IntPtr new_Words__SWIG_0();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Words__SWIG_1")]
    public static extern IntPtr new_Words__SWIG_1(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_new_Words__SWIG_2")]
    public static extern IntPtr new_Words__SWIG_2(int jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_CONLLU_V1_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string OutputFormat_CONLLU_V1_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_CONLLU_V2_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string OutputFormat_CONLLU_V2_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_finishDocument")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string OutputFormat_finishDocument(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_HORIZONTAL_PARAGRAPHS_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string OutputFormat_HORIZONTAL_PARAGRAPHS_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newConlluOutputFormat__SWIG_0")]
    public static extern IntPtr OutputFormat_newConlluOutputFormat__SWIG_0(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newConlluOutputFormat__SWIG_1")]
    public static extern IntPtr OutputFormat_newConlluOutputFormat__SWIG_1();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newEpeOutputFormat__SWIG_0")]
    public static extern IntPtr OutputFormat_newEpeOutputFormat__SWIG_0(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newEpeOutputFormat__SWIG_1")]
    public static extern IntPtr OutputFormat_newEpeOutputFormat__SWIG_1();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newHorizontalOutputFormat__SWIG_0")]
    public static extern IntPtr OutputFormat_newHorizontalOutputFormat__SWIG_0(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newHorizontalOutputFormat__SWIG_1")]
    public static extern IntPtr OutputFormat_newHorizontalOutputFormat__SWIG_1();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newMatxinOutputFormat__SWIG_0")]
    public static extern IntPtr OutputFormat_newMatxinOutputFormat__SWIG_0(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newMatxinOutputFormat__SWIG_1")]
    public static extern IntPtr OutputFormat_newMatxinOutputFormat__SWIG_1();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newOutputFormat")]
    public static extern IntPtr OutputFormat_newOutputFormat(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newPlaintextOutputFormat__SWIG_0")]
    public static extern IntPtr OutputFormat_newPlaintextOutputFormat__SWIG_0(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newPlaintextOutputFormat__SWIG_1")]
    public static extern IntPtr OutputFormat_newPlaintextOutputFormat__SWIG_1();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newVerticalOutputFormat__SWIG_0")]
    public static extern IntPtr OutputFormat_newVerticalOutputFormat__SWIG_0(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_newVerticalOutputFormat__SWIG_1")]
    public static extern IntPtr OutputFormat_newVerticalOutputFormat__SWIG_1();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_PLAINTEXT_NORMALIZED_SPACES_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string OutputFormat_PLAINTEXT_NORMALIZED_SPACES_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_VERTICAL_PARAGRAPHS_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string OutputFormat_VERTICAL_PARAGRAPHS_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_OutputFormat_writeSentence")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string OutputFormat_writeSentence(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Pipeline_DEFAULT_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Pipeline_DEFAULT_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Pipeline_NONE_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Pipeline_NONE_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Pipeline_process__SWIG_0")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Pipeline_process__SWIG_0(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Pipeline_process__SWIG_1")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Pipeline_process__SWIG_1(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Pipeline_setDocumentId")]
    public static extern void Pipeline_setDocumentId(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Pipeline_setImmediate")]
    public static extern void Pipeline_setImmediate(HandleRef jarg1, bool jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Pipeline_setInput")]
    public static extern void Pipeline_setInput(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Pipeline_setModel")]
    public static extern void Pipeline_setModel(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Pipeline_setOutput")]
    public static extern void Pipeline_setOutput(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Pipeline_setParser")]
    public static extern void Pipeline_setParser(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Pipeline_setTagger")]
    public static extern void Pipeline_setTagger(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_ProcessingError_message_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string ProcessingError_message_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_ProcessingError_message_set")]
    public static extern void ProcessingError_message_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_ProcessingError_occurred")]
    public static extern bool ProcessingError_occurred(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_addWord")]
    public static extern IntPtr Sentence_addWord(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_clear")]
    public static extern void Sentence_clear(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_comments_get")]
    public static extern IntPtr Sentence_comments_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_comments_set")]
    public static extern void Sentence_comments_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_empty")]
    public static extern bool Sentence_empty(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_emptyNodes_get")]
    public static extern IntPtr Sentence_emptyNodes_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_emptyNodes_set")]
    public static extern void Sentence_emptyNodes_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_getNewDoc")]
    public static extern bool Sentence_getNewDoc(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_getNewDocId")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Sentence_getNewDocId(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_getNewPar")]
    public static extern bool Sentence_getNewPar(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_getNewParId")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Sentence_getNewParId(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_getSentId")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Sentence_getSentId(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_getText")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Sentence_getText(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_multiwordTokens_get")]
    public static extern IntPtr Sentence_multiwordTokens_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_multiwordTokens_set")]
    public static extern void Sentence_multiwordTokens_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_rootForm_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Sentence_rootForm_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_setHead")]
    public static extern void Sentence_setHead(HandleRef jarg1, int jarg2, int jarg3,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg4);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_setNewDoc__SWIG_0")]
    public static extern void Sentence_setNewDoc__SWIG_0(HandleRef jarg1, bool jarg2,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_setNewDoc__SWIG_1")]
    public static extern void Sentence_setNewDoc__SWIG_1(HandleRef jarg1, bool jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_setNewPar__SWIG_0")]
    public static extern void Sentence_setNewPar__SWIG_0(HandleRef jarg1, bool jarg2,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_setNewPar__SWIG_1")]
    public static extern void Sentence_setNewPar__SWIG_1(HandleRef jarg1, bool jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_setSentId")]
    public static extern void Sentence_setSentId(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_setText")]
    public static extern void Sentence_setText(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_unlinkAllNodes")]
    public static extern void Sentence_unlinkAllNodes(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_words_get")]
    public static extern IntPtr Sentence_words_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentence_words_set")]
    public static extern void Sentence_words_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_Add")]
    public static extern void Sentences_Add(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_AddRange")]
    public static extern void Sentences_AddRange(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_capacity")]
    public static extern uint Sentences_capacity(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_Clear")]
    public static extern void Sentences_Clear(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_getitem")]
    public static extern IntPtr Sentences_getitem(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_getitemcopy")]
    public static extern IntPtr Sentences_getitemcopy(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_GetRange")]
    public static extern IntPtr Sentences_GetRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_Insert")]
    public static extern void Sentences_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_InsertRange")]
    public static extern void Sentences_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_RemoveAt")]
    public static extern void Sentences_RemoveAt(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_RemoveRange")]
    public static extern void Sentences_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_Repeat")]
    public static extern IntPtr Sentences_Repeat(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_reserve")]
    public static extern void Sentences_reserve(HandleRef jarg1, uint jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_Reverse__SWIG_0")]
    public static extern void Sentences_Reverse__SWIG_0(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_Reverse__SWIG_1")]
    public static extern void Sentences_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_setitem")]
    public static extern void Sentences_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_SetRange")]
    public static extern void Sentences_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Sentences_size")]
    public static extern uint Sentences_size(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_form_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Token_form_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_form_set")]
    public static extern void Token_form_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_getSpaceAfter")]
    public static extern bool Token_getSpaceAfter(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_getSpacesAfter")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Token_getSpacesAfter(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_getSpacesBefore")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Token_getSpacesBefore(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_getSpacesInToken")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Token_getSpacesInToken(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_getTokenRange")]
    public static extern bool Token_getTokenRange(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_getTokenRangeEnd")]
    public static extern uint Token_getTokenRangeEnd(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_getTokenRangeStart")]
    public static extern uint Token_getTokenRangeStart(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_misc_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Token_misc_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_misc_set")]
    public static extern void Token_misc_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_setSpaceAfter")]
    public static extern void Token_setSpaceAfter(HandleRef jarg1, bool jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_setSpacesAfter")]
    public static extern void Token_setSpacesAfter(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_setSpacesBefore")]
    public static extern void Token_setSpacesBefore(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_setSpacesInToken")]
    public static extern void Token_setSpacesInToken(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Token_setTokenRange")]
    public static extern void Token_setTokenRange(HandleRef jarg1, uint jarg2, uint jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Trainer_DEFAULT_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Trainer_DEFAULT_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Trainer_NONE_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Trainer_NONE_get();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Trainer_train__SWIG_0")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Trainer_train__SWIG_0(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1, HandleRef jarg2, HandleRef jarg3,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg4, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg5, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg6, HandleRef jarg7);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Trainer_train__SWIG_1")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Trainer_train__SWIG_1(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg1, HandleRef jarg2, HandleRef jarg3,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg4, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg5, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg6);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Version_current")]
    public static extern IntPtr Version_current();

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Version_major_get")]
    public static extern uint Version_major_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Version_major_set")]
    public static extern void Version_major_set(HandleRef jarg1, uint jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Version_minor_get")]
    public static extern uint Version_minor_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Version_minor_set")]
    public static extern void Version_minor_set(HandleRef jarg1, uint jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Version_patch_get")]
    public static extern uint Version_patch_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Version_patch_set")]
    public static extern void Version_patch_set(HandleRef jarg1, uint jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Version_prerelease_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Version_prerelease_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Version_prerelease_set")]
    public static extern void Version_prerelease_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_children_get")]
    public static extern IntPtr Word_children_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_children_set")]
    public static extern void Word_children_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_deprel_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Word_deprel_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_deprel_set")]
    public static extern void Word_deprel_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_deps_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Word_deps_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_deps_set")]
    public static extern void Word_deps_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_feats_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Word_feats_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_feats_set")]
    public static extern void Word_feats_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_head_get")]
    public static extern int Word_head_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_head_set")]
    public static extern void Word_head_set(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_id_get")]
    public static extern int Word_id_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_id_set")]
    public static extern void Word_id_set(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_lemma_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Word_lemma_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_lemma_set")]
    public static extern void Word_lemma_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);


    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_SWIGUpcast")]
    public static extern IntPtr Word_SWIGUpcast(IntPtr jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_upostag_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Word_upostag_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_upostag_set")]
    public static extern void Word_upostag_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_xpostag_get")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
    public static extern string Word_xpostag_get(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Word_xpostag_set")]
    public static extern void Word_xpostag_set(HandleRef jarg1,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))]
      string jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_Add")]
    public static extern void Words_Add(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_AddRange")]
    public static extern void Words_AddRange(HandleRef jarg1, HandleRef jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_capacity")]
    public static extern uint Words_capacity(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_Clear")]
    public static extern void Words_Clear(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_getitem")]
    public static extern IntPtr Words_getitem(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_getitemcopy")]
    public static extern IntPtr Words_getitemcopy(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_GetRange")]
    public static extern IntPtr Words_GetRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_Insert")]
    public static extern void Words_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_InsertRange")]
    public static extern void Words_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_RemoveAt")]
    public static extern void Words_RemoveAt(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_RemoveRange")]
    public static extern void Words_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_Repeat")]
    public static extern IntPtr Words_Repeat(HandleRef jarg1, int jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_reserve")]
    public static extern void Words_reserve(HandleRef jarg1, uint jarg2);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_Reverse__SWIG_0")]
    public static extern void Words_Reverse__SWIG_0(HandleRef jarg1);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_Reverse__SWIG_1")]
    public static extern void Words_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_setitem")]
    public static extern void Words_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_SetRange")]
    public static extern void Words_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("udpipe_csharp", EntryPoint = "CSharp_Words_size")]
    public static extern uint Words_size(HandleRef jarg1);

    protected class SWIGExceptionHelper
    {
      public delegate void ExceptionArgumentDelegate(string message, string paramName);

      public delegate void ExceptionDelegate(string message);

      private static readonly ExceptionDelegate applicationDelegate = SetPendingApplicationException;

      private static readonly ExceptionDelegate arithmeticDelegate = SetPendingArithmeticException;
      private static readonly ExceptionDelegate divideByZeroDelegate = SetPendingDivideByZeroException;
      private static readonly ExceptionDelegate indexOutOfRangeDelegate = SetPendingIndexOutOfRangeException;
      private static readonly ExceptionDelegate invalidCastDelegate = SetPendingInvalidCastException;
      private static readonly ExceptionDelegate invalidOperationDelegate = SetPendingInvalidOperationException;
      private static readonly ExceptionDelegate ioDelegate = SetPendingIOException;
      private static readonly ExceptionDelegate nullReferenceDelegate = SetPendingNullReferenceException;
      private static readonly ExceptionDelegate outOfMemoryDelegate = SetPendingOutOfMemoryException;
      private static readonly ExceptionDelegate overflowDelegate = SetPendingOverflowException;
      private static readonly ExceptionDelegate systemDelegate = SetPendingSystemException;
      private static readonly ExceptionArgumentDelegate argumentDelegate = SetPendingArgumentException;
      private static readonly ExceptionArgumentDelegate argumentNullDelegate = SetPendingArgumentNullException;

      private static readonly ExceptionArgumentDelegate argumentOutOfRangeDelegate =
        SetPendingArgumentOutOfRangeException;


      static SWIGExceptionHelper()
      {
        SWIGRegisterExceptionCallbacks_udpipe_csharp(
          applicationDelegate,
          arithmeticDelegate,
          divideByZeroDelegate,
          indexOutOfRangeDelegate,
          invalidCastDelegate,
          invalidOperationDelegate,
          ioDelegate,
          nullReferenceDelegate,
          outOfMemoryDelegate,
          overflowDelegate,
          systemDelegate);

        SWIGRegisterExceptionCallbacksArgument_udpipe_csharp(
          argumentDelegate,
          argumentNullDelegate,
          argumentOutOfRangeDelegate);
      }

      [DllImport("udpipe_csharp", EntryPoint = "SWIGRegisterExceptionCallbacks_udpipe_csharp")]
      public static extern void SWIGRegisterExceptionCallbacks_udpipe_csharp(
        ExceptionDelegate applicationDelegate,
        ExceptionDelegate arithmeticDelegate,
        ExceptionDelegate divideByZeroDelegate,
        ExceptionDelegate indexOutOfRangeDelegate,
        ExceptionDelegate invalidCastDelegate,
        ExceptionDelegate invalidOperationDelegate,
        ExceptionDelegate ioDelegate,
        ExceptionDelegate nullReferenceDelegate,
        ExceptionDelegate outOfMemoryDelegate,
        ExceptionDelegate overflowDelegate,
        ExceptionDelegate systemExceptionDelegate);

      [DllImport("udpipe_csharp", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_udpipe_csharp")]
      public static extern void SWIGRegisterExceptionCallbacksArgument_udpipe_csharp(
        ExceptionArgumentDelegate argumentDelegate,
        ExceptionArgumentDelegate argumentNullDelegate,
        ExceptionArgumentDelegate argumentOutOfRangeDelegate);

      private static void SetPendingApplicationException(string message)
      {
        SWIGPendingException.Set(new ApplicationException(message, SWIGPendingException.Retrieve()));
      }

      private static void SetPendingArgumentException(string message, string paramName)
      {
        SWIGPendingException.Set(new ArgumentException(message, paramName, SWIGPendingException.Retrieve()));
      }

      private static void SetPendingArgumentNullException(string message, string paramName)
      {
        Exception e = SWIGPendingException.Retrieve();
        if (e != null) message = message + " Inner Exception: " + e.Message;
        SWIGPendingException.Set(new ArgumentNullException(paramName, message));
      }

      private static void SetPendingArgumentOutOfRangeException(string message, string paramName)
      {
        Exception e = SWIGPendingException.Retrieve();
        if (e != null) message = message + " Inner Exception: " + e.Message;
        SWIGPendingException.Set(new ArgumentOutOfRangeException(paramName, message));
      }

      private static void SetPendingArithmeticException(string message)
      {
        SWIGPendingException.Set(new ArithmeticException(message, SWIGPendingException.Retrieve()));
      }

      private static void SetPendingDivideByZeroException(string message)
      {
        SWIGPendingException.Set(new DivideByZeroException(message, SWIGPendingException.Retrieve()));
      }

      private static void SetPendingIndexOutOfRangeException(string message)
      {
        SWIGPendingException.Set(new IndexOutOfRangeException(message, SWIGPendingException.Retrieve()));
      }

      private static void SetPendingInvalidCastException(string message)
      {
        SWIGPendingException.Set(new InvalidCastException(message, SWIGPendingException.Retrieve()));
      }

      private static void SetPendingInvalidOperationException(string message)
      {
        SWIGPendingException.Set(new InvalidOperationException(message, SWIGPendingException.Retrieve()));
      }

      private static void SetPendingIOException(string message)
      {
        SWIGPendingException.Set(new IOException(message, SWIGPendingException.Retrieve()));
      }

      private static void SetPendingNullReferenceException(string message)
      {
        SWIGPendingException.Set(new NullReferenceException(message, SWIGPendingException.Retrieve()));
      }

      private static void SetPendingOutOfMemoryException(string message)
      {
        SWIGPendingException.Set(new OutOfMemoryException(message, SWIGPendingException.Retrieve()));
      }

      private static void SetPendingOverflowException(string message)
      {
        SWIGPendingException.Set(new OverflowException(message, SWIGPendingException.Retrieve()));
      }

      private static void SetPendingSystemException(string message)
      {
        SWIGPendingException.Set(new SystemException(message, SWIGPendingException.Retrieve()));
      }
    }

    public class SWIGPendingException
    {
      private static int numExceptionsPending;

      [ThreadStatic] private static Exception pendingException;

      public static bool Pending
      {
        get
        {
          bool pending = false;
          if (numExceptionsPending > 0)
            if (pendingException != null)
              pending = true;
          return pending;
        }
      }

      public static Exception Retrieve()
      {
        Exception e = null;
        if (numExceptionsPending > 0)
          if (pendingException != null)
          {
            e = pendingException;
            pendingException = null;
            lock (typeof(udpipe_csharpPINVOKE))
            {
              numExceptionsPending--;
            }
          }

        return e;
      }

      public static void Set(Exception e)
      {
        if (pendingException != null)
          throw new ApplicationException(
            "FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" +
            pendingException + ")", e);
        pendingException = e;
        lock (typeof(udpipe_csharpPINVOKE))
        {
          numExceptionsPending++;
        }
      }
    }


    protected class SWIGStringHelper
    {
      public delegate string SWIGStringDelegate(string message);

      private static readonly SWIGStringDelegate stringDelegate = CreateString;

      static SWIGStringHelper()
      {
        SWIGRegisterStringCallback_udpipe_csharp(stringDelegate);
      }

      [DllImport("udpipe_csharp", EntryPoint = "SWIGRegisterStringCallback_udpipe_csharp")]
      public static extern void SWIGRegisterStringCallback_udpipe_csharp(SWIGStringDelegate stringDelegate);

      private static string CreateString(string cString)
      {
        return cString;
      }
    }

    public class UTF8Marshaler : ICustomMarshaler
    {
      private static UTF8Marshaler static_instance;

      public IntPtr MarshalManagedToNative(object managedObj)
      {
        if (managedObj == null)
          return IntPtr.Zero;
        if (!(managedObj is string))
          throw new MarshalDirectiveException("UTF8Marshaler must be used on a string.");

        // not null terminated
        byte[] strbuf = Encoding.UTF8.GetBytes((string) managedObj);
        IntPtr buffer = Marshal.AllocHGlobal(strbuf.Length + 1);
        Marshal.Copy(strbuf, 0, buffer, strbuf.Length);

        // write the terminating null
        Marshal.WriteByte(buffer + strbuf.Length, 0);
        return buffer;
      }

      public object MarshalNativeToManaged(IntPtr pNativeData)
      {
        int length = 0;
        while (Marshal.ReadByte(pNativeData, length) != 0)
          length++;

        // should not be null terminated
        byte[] strbuf = new byte[length];
        // skip the trailing null
        Marshal.Copy(pNativeData, strbuf, 0, length);
        string data = Encoding.UTF8.GetString(strbuf);
        return data;
      }

      public void CleanUpNativeData(IntPtr pNativeData)
      {
        Marshal.FreeHGlobal(pNativeData);
      }

      public void CleanUpManagedData(object managedObj)
      {
      }

      public int GetNativeDataSize()
      {
        return -1;
      }

      public static ICustomMarshaler GetInstance(string cookie)
      {
        if (static_instance == null)
          return static_instance = new UTF8Marshaler();
        return static_instance;
      }
    }
  }
}