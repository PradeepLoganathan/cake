﻿using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Common.Tools.Cake
{
    /// <summary>
    /// Contains functionality related to running Cake scripts out of process.
    /// </summary>
    public static class CakeAliases
    {
        /// <summary>
        /// Executes cake script out of process
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cakeScriptPath">The script file.</param>
        [CakeMethodAlias]
        public static void CakeExecuteScript(this ICakeContext context, FilePath cakeScriptPath)
        {
            context.CakeExecuteScript(cakeScriptPath, null);
        }

        /// <summary>
        /// Executes cake script out of process
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cakeScriptPath">The script file.</param>
        /// <param name="settings">The settings <see cref="CakeSettings"/>.</param>
        [CakeMethodAlias]
        public static void CakeExecuteScript(this ICakeContext context, FilePath cakeScriptPath, CakeSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var cakeRunner = new CakeRunner(context.FileSystem, context.Environment, context.Globber, context.ProcessRunner);
            cakeRunner.ExecuteScript(cakeScriptPath, settings);
        }

        /// <summary>
        /// Executes Cake expression out of process
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cakeExpression">The cake expression</param>
        [CakeMethodAlias]
        public static void CakeExecuteExpression(this ICakeContext context, string cakeExpression)
        {
            context.CakeExecuteExpression(cakeExpression, null);
        }

        /// <summary>
        /// Executes Cake expression out of process
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cakeExpression">The cake expression</param>
        /// <param name="settings">The settings <see cref="CakeSettings"/>.</param>
        [CakeMethodAlias]
        public static void CakeExecuteExpression(this ICakeContext context, string cakeExpression, CakeSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var cakeRunner = new CakeRunner(context.FileSystem, context.Environment, context.Globber, context.ProcessRunner);
            cakeRunner.ExecuteExpression(cakeExpression, settings);
        }
    }
}