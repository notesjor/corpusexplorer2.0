﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Betacode
{
  public static class BetacodeConverter
  {
    /*
     * 
     * COPYRIGHT NOTICE
     * Original _beatcodeToUnicode from https://github.com/zfletch/beta-code-converter-js/
     * LICENCE: MIT Licence
     * 
     */

    public static List<KeyValuePair<string, string>> _beatcodeToUnicode = new Dictionary<string, string>
    {
      {"a", "α"},
      {"*a", "Α"},
      {"b", "β"},
      {"*b", "Β"},
      {"g", "γ"},
      {"*g", "Γ"},
      {"d", "δ"},
      {"*d", "Δ"},
      {"e", "ε"},
      {"*e", "Ε"},
      {"z", "ζ"},
      {"*z", "Ζ"},
      {"h", "η"},
      {"*h", "Η"},
      {"q", "θ"},
      {"*q", "Θ"},
      {"i", "ι"},
      {"*i", "Ι"},
      {"k", "κ"},
      {"*k", "Κ"},
      {"l", "λ"},
      {"*l", "Λ"},
      {"m", "μ"},
      {"*m", "Μ"},
      {"n", "ν"},
      {"*n", "Ν"},
      {"c", "ξ"},
      {"*c", "Ξ"},
      {"o", "ο"},
      {"*o", "Ο"},
      {"p", "π"},
      {"*p", "Π"},
      {"r", "ρ"},
      {"*r", "Ρ"},
      {"s", "σ"},
      {"*s", "Σ"},
      {"s1", "σ"},
      {"*s1", "Σ"},
      {"s2", "ς"},
      {"*s2", "Σ"},
      {"j", "ς"},
      {"*j", "Σ"},
      {"s3", "ϲ"},
      {"*s3", "Ϲ"},
      {"t", "τ"},
      {"*t", "Τ"},
      {"u", "υ"},
      {"*u", "Υ"},
      {"f", "φ"},
      {"*f", "Φ"},
      {"x", "χ"},
      {"*x", "Χ"},
      {"y", "ψ"},
      {"*y", "Ψ"},
      {"w", "ω"},
      {"*w", "Ω"},
      {".", "."},
      {"},", "},"},
      {":", "·"},
      {";", ";"},
      {"-", "-"},
      {"_", "—"},
      {")", "ʼ"},
      {"(", "ʽ"},
      {"/", " ́"},
      {"=", " ͂"},
      {"\\", "`"},
      {"+", " ̈"},
      {"a)", "ἀ"},
      {"a(", "ἁ"},
      {"a/", "ά"},
      {"a\\", "ὰ"},
      {"a=", "ᾶ"},
      {"a|", "ᾳ"},
      {"a)|", "ᾀ"},
      {"a(|", "ᾁ"},
      {"a/|", "ᾴ"},
      {"a\\|", "ᾲ"},
      {"a=|", "ᾷ"},
      {"a)/", "ἄ"},
      {"a(/", "ἅ"},
      {"a)\\", "ἂ"},
      {"a(\\", "ἃ"},
      {"a)=", "ἆ"},
      {"a(=", "ἇ"},
      {"a)/|", "ᾄ"},
      {"a(/|", "ᾅ"},
      {"a(\\|", "ᾃ"},
      {"a)=|", "ᾆ"},
      {"a(=|", "ᾇ"},
      {"*)a", "Ἀ"},
      {"*(a", "Ἁ"},
      {"*/a", "Ά"},
      {"*\\a", "Ὰ"},
      {"*|a", "ᾼ"},
      {"*)|a", "ᾈ"},
      {"*(|a", "ᾉ"},
      {"*)/a", "Ἄ"},
      {"*(/a", "Ἅ"},
      {"*(\\a", "Ἃ"},
      {"*)=a", "Ἆ"},
      {"*(=a", "Ἇ"},
      {"*)/|a", "ᾌ"},
      {"*(/|a", "ᾍ"},
      {"*(\\|a", "ᾋ"},
      {"*)=|a", "ᾎ"},
      {"*(=|a", "ᾏ"},
      {"e)", "ἐ"},
      {"e(", "ἑ"},
      {"e/", "έ"},
      {"e\\", "ὲ"},
      {"e)\\", "ἒ"},
      {"e(\\", "ἓ"},
      {"e)/", "ἔ"},
      {"e(/", "ἕ"},
      {"*)e", "Ἐ"},
      {"*(e", "Ἑ"},
      {"*/e", "Έ"},
      {"*\\e", "Ὲ"},
      {"*)\\e", "Ἒ"},
      {"*(\\e", "Ἓ"},
      {"*)/e", "Ἔ"},
      {"*(/e", "Ἕ"},
      {"h)", "ἠ"},
      {"h(", "ἡ"},
      {"h/", "ή"},
      {"h\\", "ὴ"},
      {"h=", "ῆ"},
      {"h|", "ῃ"},
      {"h)|", "ᾐ"},
      {"h(|", "ᾑ"},
      {"h/|", "ῄ"},
      {"h\\|", "ῂ"},
      {"h=|", "ῇ"},
      {"h)/", "ἤ"},
      {"h(/", "ἥ"},
      {"h(\\", "ἣ"},
      {"h)=", "ἦ"},
      {"h(=", "ἧ"},
      {"h)/|", "ᾔ"},
      {"h(/|", "ᾕ"},
      {"h(\\|", "ᾓ"},
      {"h)=|", "ᾖ"},
      {"h(=|", "ᾗ"},
      {"*)h", "Ἠ"},
      {"*(h", "Ἡ"},
      {"*/h", "Ή"},
      {"*\\h", "Ὴ"},
      {"*|h", "ῌ"},
      {"*)|h", "ᾘ"},
      {"*(|h", "ᾙ"},
      {"*)/h", "Ἤ"},
      {"*(/h", "Ἥ"},
      {"*(\\h", "Ἣ"},
      {"*)=h", "Ἦ"},
      {"*(=h", "Ἧ"},
      {"*)/|h", "ᾜ"},
      {"*(/|h", "ᾝ"},
      {"*(\\|h", "ᾛ"},
      {"*)=|h", "ᾞ"},
      {"*(=|h", "ᾟ"},
      {"i)", "ἰ"},
      {"i(", "ἱ"},
      {"i/", "ί"},
      {"i\\", "ὶ"},
      {"i=", "ῖ"},
      {"i+", "ϊ"},
      {"i)\\", "ἲ"},
      {"i(\\", "ἳ"},
      {"i)/", "ἴ"},
      {"i(/", "ἵ"},
      {"i)=", "ἶ"},
      {"i(=", "ἷ"},
      {"i/+", "ΐ"},
      {"i\\+", "ῒ"},
      {"i=+", "ῗ"},
      {"*)i", "Ἰ"},
      {"*(i", "Ἱ"},
      {"*/i", "Ί"},
      {"*\\i", "Ὶ"},
      {"*+i", "Ϊ"},
      {"*)\\i", "Ἲ"},
      {"*(\\i", "Ἳ"},
      {"*)/i", "Ἴ"},
      {"*(/i", "Ἵ"},
      {"*)=i", "Ἶ"},
      {"*(=i", "Ἷ"},
      {"o)", "ὀ"},
      {"o(", "ὁ"},
      {"o/", "ό"},
      {"o\\", "ὸ"},
      {"o)\\", "ὂ"},
      {"o(\\", "ὃ"},
      {"o)/", "ὄ"},
      {"o(/", "ὅ"},
      {"*)o", "Ὀ"},
      {"*(o", "Ὁ"},
      {"*/o", "Ό"},
      {"*\\o", "Ὸ"},
      {"*)\\o", "Ὂ"},
      {"*(\\o", "Ὃ"},
      {"*)/o", "Ὄ"},
      {"*(/o", "Ὅ"},
      {"u)", "ὐ"},
      {"u(", "ὑ"},
      {"u/", "ύ"},
      {"u\\", "ὺ"},
      {"u=", "ῦ"},
      {"u+", "ϋ"},
      {"u)\\", "ὒ"},
      {"u(\\", "ὓ"},
      {"u)/", "ὔ"},
      {"u(/", "ὕ"},
      {"u)=", "ὖ"},
      {"u(=", "ὗ"},
      {"u/+", "ΰ"},
      {"u\\+", "ῢ"},
      {"u=+", "ῧ"},
      {"*(u", "Ὑ"},
      {"*/u", "Ύ"},
      {"*\\u", "Ὺ"},
      {"*+u", "Ϋ"},
      {"*(\\u", "Ὓ"},
      {"*(/u", "Ὕ"},
      {"*(=u", "Ὗ"},
      {"w)", "ὠ"},
      {"w(", "ὡ"},
      {"w/", "ώ"},
      {"w\\", "ὼ"},
      {"w=", "ῶ"},
      {"w|", "ῳ"},
      {"w)|", "ᾠ"},
      {"w(|", "ᾡ"},
      {"w/|", "ῴ"},
      {"w\\|", "ῲ"},
      {"w=|", "ῷ"},
      {"w)/", "ὤ"},
      {"w(/", "ὥ"},
      {"w(\\", "ὣ"},
      {"w)=", "ὦ"},
      {"w(=", "ὧ"},
      {"w)/|", "ᾤ"},
      {"w(/|", "ᾥ"},
      {"w(\\|", "ᾣ"},
      {"w)=|", "ᾦ"},
      {"w(=|", "ᾧ"},
      {"*)w", "Ὠ"},
      {"*(w", "Ὡ"},
      {"*/w", "Ώ"},
      {"*\\w", "Ὼ"},
      {"*|w", "ῼ"},
      {"*)|w", "ᾨ"},
      {"*(|w", "ᾩ"},
      {"*)/w", "Ὤ"},
      {"*(/w", "Ὥ"},
      {"*(\\w", "Ὣ"},
      {"*)=w", "Ὦ"},
      {"*(=w", "Ὧ"},
      {"*)/|w", "ᾬ"},
      {"*(/|w", "ᾭ"},
      {"*(\\|w", "ᾫ"},
      {"*)=|w", "ᾮ"},
      {"*(=|w", "ᾯ"},
      {"A", "α"},
      {"*A", "Α"},
      {"B", "β"},
      {"*B", "Β"},
      {"G", "γ"},
      {"*G", "Γ"},
      {"D", "δ"},
      {"*D", "Δ"},
      {"E", "ε"},
      {"*E", "Ε"},
      {"Z", "ζ"},
      {"*Z", "Ζ"},
      {"H", "η"},
      {"*H", "Η"},
      {"Q", "θ"},
      {"*Q", "Θ"},
      {"I", "ι"},
      {"*I", "Ι"},
      {"K", "κ"},
      {"*K", "Κ"},
      {"L", "λ"},
      {"*L", "Λ"},
      {"M", "μ"},
      {"*M", "Μ"},
      {"N", "ν"},
      {"*N", "Ν"},
      {"C", "ξ"},
      {"*C", "Ξ"},
      {"O", "ο"},
      {"*O", "Ο"},
      {"P", "π"},
      {"*P", "Π"},
      {"R", "ρ"},
      {"*R", "Ρ"},
      {"S", "σ"},
      {"*S", "Σ"},
      {"S1", "σ"},
      {"*S1", "Σ"},
      {"S2", "ς"},
      {"*S2", "Σ"},
      {"J", "ς"},
      {"*J", "Σ"},
      {"S3", "ϲ"},
      {"*S3", "Ϲ"},
      {"T", "τ"},
      {"*T", "Τ"},
      {"U", "υ"},
      {"*U", "Υ"},
      {"F", "φ"},
      {"*F", "Φ"},
      {"X", "χ"},
      {"*X", "Χ"},
      {"Y", "ψ"},
      {"*Y", "Ψ"},
      {"W", "ω"},
      {"*W", "Ω"},
      {".", "."},
      {"},", "},"},
      {":", "·"},
      {";", ";"},
      {"-", "-"},
      {"_", "—"},
      {")", "ʼ"},
      {"(", "ʽ"},
      {"/", " ́"},
      {"=", " ͂"},
      {"\\", "`"},
      {"+", " ̈"},
      {"A)", "ἀ"},
      {"A(", "ἁ"},
      {"A/", "ά"},
      {"A\\", "ὰ"},
      {"A=", "ᾶ"},
      {"A|", "ᾳ"},
      {"A)|", "ᾀ"},
      {"A(|", "ᾁ"},
      {"A/|", "ᾴ"},
      {"A\\|", "ᾲ"},
      {"A=|", "ᾷ"},
      {"A)/", "ἄ"},
      {"A(/", "ἅ"},
      {"A)\\", "ἂ"},
      {"A(\\", "ἃ"},
      {"A)=", "ἆ"},
      {"A(=", "ἇ"},
      {"A)/|", "ᾄ"},
      {"A(/|", "ᾅ"},
      {"A(\\|", "ᾃ"},
      {"A)=|", "ᾆ"},
      {"A(=|", "ᾇ"},
      {"*)A", "Ἀ"},
      {"*(A", "Ἁ"},
      {"*/A", "Ά"},
      {"*\\A", "Ὰ"},
      {"*|A", "ᾼ"},
      {"*)|A", "ᾈ"},
      {"*(|A", "ᾉ"},
      {"*)/A", "Ἄ"},
      {"*(/A", "Ἅ"},
      {"*(\\A", "Ἃ"},
      {"*)=A", "Ἆ"},
      {"*(=A", "Ἇ"},
      {"*)/|A", "ᾌ"},
      {"*(/|A", "ᾍ"},
      {"*(\\|A", "ᾋ"},
      {"*)=|A", "ᾎ"},
      {"*(=|A", "ᾏ"},
      {"E)", "ἐ"},
      {"E(", "ἑ"},
      {"E/", "έ"},
      {"E\\", "ὲ"},
      {"E)\\", "ἒ"},
      {"E(\\", "ἓ"},
      {"E)/", "ἔ"},
      {"E(/", "ἕ"},
      {"*)E", "Ἐ"},
      {"*(E", "Ἑ"},
      {"*/E", "Έ"},
      {"*\\E", "Ὲ"},
      {"*)\\E", "Ἒ"},
      {"*(\\E", "Ἓ"},
      {"*)/E", "Ἔ"},
      {"*(/E", "Ἕ"},
      {"H)", "ἠ"},
      {"H(", "ἡ"},
      {"H/", "ή"},
      {"H\\", "ὴ"},
      {"H=", "ῆ"},
      {"H|", "ῃ"},
      {"H)|", "ᾐ"},
      {"H(|", "ᾑ"},
      {"H/|", "ῄ"},
      {"H\\|", "ῂ"},
      {"H=|", "ῇ"},
      {"H)/", "ἤ"},
      {"H(/", "ἥ"},
      {"H(\\", "ἣ"},
      {"H)=", "ἦ"},
      {"H(=", "ἧ"},
      {"H)/|", "ᾔ"},
      {"H(/|", "ᾕ"},
      {"H(\\|", "ᾓ"},
      {"H)=|", "ᾖ"},
      {"H(=|", "ᾗ"},
      {"*)H", "Ἠ"},
      {"*(H", "Ἡ"},
      {"*/H", "Ή"},
      {"*\\H", "Ὴ"},
      {"*|H", "ῌ"},
      {"*)|H", "ᾘ"},
      {"*(|H", "ᾙ"},
      {"*)/H", "Ἤ"},
      {"*(/H", "Ἥ"},
      {"*(\\H", "Ἣ"},
      {"*)=H", "Ἦ"},
      {"*(=H", "Ἧ"},
      {"*)/|H", "ᾜ"},
      {"*(/|H", "ᾝ"},
      {"*(\\|H", "ᾛ"},
      {"*)=|H", "ᾞ"},
      {"*(=|H", "ᾟ"},
      {"I)", "ἰ"},
      {"I(", "ἱ"},
      {"I/", "ί"},
      {"I\\", "ὶ"},
      {"I=", "ῖ"},
      {"I+", "ϊ"},
      {"I)\\", "ἲ"},
      {"I(\\", "ἳ"},
      {"I)/", "ἴ"},
      {"I(/", "ἵ"},
      {"I)=", "ἶ"},
      {"I(=", "ἷ"},
      {"I/+", "ΐ"},
      {"I\\+", "ῒ"},
      {"I=+", "ῗ"},
      {"*)I", "Ἰ"},
      {"*(I", "Ἱ"},
      {"*/I", "Ί"},
      {"*\\I", "Ὶ"},
      {"*+I", "Ϊ"},
      {"*)\\I", "Ἲ"},
      {"*(\\I", "Ἳ"},
      {"*)/I", "Ἴ"},
      {"*(/I", "Ἵ"},
      {"*)=I", "Ἶ"},
      {"*(=I", "Ἷ"},
      {"O)", "ὀ"},
      {"O(", "ὁ"},
      {"O/", "ό"},
      {"O\\", "ὸ"},
      {"O)\\", "ὂ"},
      {"O(\\", "ὃ"},
      {"O)/", "ὄ"},
      {"O(/", "ὅ"},
      {"*)O", "Ὀ"},
      {"*(O", "Ὁ"},
      {"*/O", "Ό"},
      {"*\\O", "Ὸ"},
      {"*)\\O", "Ὂ"},
      {"*(\\O", "Ὃ"},
      {"*)/O", "Ὄ"},
      {"*(/O", "Ὅ"},
      {"U)", "ὐ"},
      {"U(", "ὑ"},
      {"U/", "ύ"},
      {"U\\", "ὺ"},
      {"U=", "ῦ"},
      {"U+", "ϋ"},
      {"U)\\", "ὒ"},
      {"U(\\", "ὓ"},
      {"U)/", "ὔ"},
      {"U(/", "ὕ"},
      {"U)=", "ὖ"},
      {"U(=", "ὗ"},
      {"U/+", "ΰ"},
      {"U\\+", "ῢ"},
      {"U=+", "ῧ"},
      {"*(U", "Ὑ"},
      {"*/U", "Ύ"},
      {"*\\U", "Ὺ"},
      {"*+U", "Ϋ"},
      {"*(\\U", "Ὓ"},
      {"*(/U", "Ὕ"},
      {"*(=U", "Ὗ"},
      {"W)", "ὠ"},
      {"W(", "ὡ"},
      {"W/", "ώ"},
      {"W\\", "ὼ"},
      {"W=", "ῶ"},
      {"W|", "ῳ"},
      {"W)|", "ᾠ"},
      {"W(|", "ᾡ"},
      {"W/|", "ῴ"},
      {"W\\|", "ῲ"},
      {"W=|", "ῷ"},
      {"W)/", "ὤ"},
      {"W(/", "ὥ"},
      {"W(\\", "ὣ"},
      {"W)=", "ὦ"},
      {"W(=", "ὧ"},
      {"W)/|", "ᾤ"},
      {"W(/|", "ᾥ"},
      {"W(\\|", "ᾣ"},
      {"W)=|", "ᾦ"},
      {"W(=|", "ᾧ"},
      {"*)W", "Ὠ"},
      {"*(W", "Ὡ"},
      {"*/W", "Ώ"},
      {"*\\W", "Ὼ"},
      {"*|W", "ῼ"},
      {"*)|W", "ᾨ"},
      {"*(|W", "ᾩ"},
      {"*)/W", "Ὤ"},
      {"*(/W", "Ὥ"},
      {"*(\\W", "Ὣ"},
      {"*)=W", "Ὦ"},
      {"*(=W", "Ὧ"},
      {"*)/|W", "ᾬ"},
      {"*(/|W", "ᾭ"},
      {"*(\\|W", "ᾫ"},
      {"*)=|W", "ᾮ"},
      {"*(=|W", "ᾯ"},
      {"_", "—"},
      {"#", "ʹ"}
    }.OrderByDescending(x => x.Key.Length).ToList();

    public static string ConvertToUnicode(string betacode)
    {
      var stb = new StringBuilder(betacode);
      foreach (var x in _beatcodeToUnicode)
        stb.Replace(x.Key, x.Value);
      return stb.ToString();
    }
  }
}