﻿using System;
using System.Runtime.InteropServices;

namespace rubydotnet
{
    public static partial class Ruby
    {
        public static class String
        {
            public static IntPtr ToPtr(string Value)
            {
                return rb_str_new(Value, Value.Length);
            }

            public static string FromPtr(IntPtr Value)
            {
                long len = Integer.FromPtr(Funcall(Value, "bytesize"));
                return Marshal.PtrToStringUTF8(rb_string_value_ptr(ref Value), (int) len);
            }

            [DllImport(RubyPath)]
            static extern IntPtr rb_str_new(string String, long Length);

            [DllImport(RubyPath)]
            static extern IntPtr rb_string_value_ptr(ref IntPtr Object);
        }
    }
}
