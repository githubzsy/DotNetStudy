﻿/*
 *┌──────────────────────────────────────────┐
 *│  描   述: DelegateTest
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/14 17:12:10
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public static class DelegateTest
    {
        /// <summary>
        /// 处理两个int，返回一个int
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public delegate int HandleTwoInt(int a,int b);

        public static int Test(int a , int b)
        {
            try
            {
                return a + b;
            }
            catch (Exception ex)
            {
                // 记录日志
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public static int Test2(int a,int b)
        {
            return InnerTest(a, b,new HandleTwoInt(Plus));
        }

        public static int Plus(int a, int b)
        {
            return a + b;
        }

        public static int InnerTest(int a , int b, HandleTwoInt handleTwoInt)
        {
            try
            {
                return handleTwoInt(a, b);
            }
            catch (Exception ex)
            {
                // 记录日志
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}
