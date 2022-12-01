/// <auto-generated />
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace MagicOnion
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::MagicOnion;
    using global::MagicOnion.Client;

    public static partial class MagicOnionInitializer
    {
        static bool isRegistered = false;

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            if(isRegistered) return;
            isRegistered = true;

            MagicOnionClientRegistry<global::ChatApp.Shared.Services.IChatService>.Register((x, y) => new ChatApp.Shared.Services.ChatServiceClient(x, y));

            StreamingHubClientRegistry<global::ChatApp.Shared.Hubs.IChatHub, global::ChatApp.Shared.Hubs.IChatHubReceiver>.Register((a, _, b, c, d, e) => new ChatApp.Shared.Hubs.ChatHubClient(a, b, c, d, e));
        }
    }
}

#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 612
#pragma warning restore 618
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace MagicOnion.Resolvers
{
    using System;
    using MessagePack;

    public class MagicOnionResolver : global::MessagePack.IFormatterResolver
    {
        public static readonly global::MessagePack.IFormatterResolver Instance = new MagicOnionResolver();

        MagicOnionResolver()
        {

        }

        public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.formatter;
        }

        static class FormatterCache<T>
        {
            public static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> formatter;

            static FormatterCache()
            {
                var f = MagicOnionResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                }
            }
        }
    }

    internal static class MagicOnionResolverGetFormatterHelper
    {
        static readonly global::System.Collections.Generic.Dictionary<Type, int> lookup;

        static MagicOnionResolverGetFormatterHelper()
        {
            lookup = new global::System.Collections.Generic.Dictionary<Type, int>(3)
            {
                {typeof(global::MagicOnion.DynamicArgumentTuple<global::System.Collections.Generic.List<global::System.Int32>, global::System.Collections.Generic.Dictionary<global::System.Int32, global::System.String>>), 0 },
                {typeof(global::System.Collections.Generic.Dictionary<global::System.Int32, global::System.String>), 1 },
                {typeof(global::System.Collections.Generic.List<global::System.Int32>), 2 },
            };
        }

        internal static object GetFormatter(Type t)
        {
            int key;
            if (!lookup.TryGetValue(t, out key))
            {
                return null;
            }

            switch (key)
            {
                case 0: return new global::MagicOnion.DynamicArgumentTupleFormatter<global::System.Collections.Generic.List<global::System.Int32>, global::System.Collections.Generic.Dictionary<global::System.Int32, global::System.String>>(default(global::System.Collections.Generic.List<global::System.Int32>), default(global::System.Collections.Generic.Dictionary<global::System.Int32, global::System.String>));
                case 1: return new global::MessagePack.Formatters.DictionaryFormatter<global::System.Int32, global::System.String>();
                case 2: return new global::MessagePack.Formatters.ListFormatter<global::System.Int32>();
                default: return null;
            }
        }
    }
}

#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 612
#pragma warning restore 618
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace ChatApp.Shared.Services
{
    using global::System;
    using global::Grpc.Core;
    using global::MagicOnion;
    using global::MagicOnion.Client;
    using global::MessagePack;
    
    [global::MagicOnion.Ignore]
    public class ChatServiceClient : global::MagicOnion.Client.MagicOnionClientBase<global::ChatApp.Shared.Services.IChatService>, global::ChatApp.Shared.Services.IChatService
    {
        class ClientCore
        {
            public global::MagicOnion.Client.Internal.RawMethodInvoker<global::System.String, global::MessagePack.Nil> GenerateException;
            public global::MagicOnion.Client.Internal.RawMethodInvoker<global::System.String, global::MessagePack.Nil> SendReportAsync;
            public ClientCore(global::MessagePack.MessagePackSerializerOptions serializerOptions)
            {
                this.GenerateException = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_RefType_ValueType<global::System.String, global::MessagePack.Nil>(global::Grpc.Core.MethodType.Unary, "IChatService", "GenerateException", serializerOptions);
                this.SendReportAsync = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_RefType_ValueType<global::System.String, global::MessagePack.Nil>(global::Grpc.Core.MethodType.Unary, "IChatService", "SendReportAsync", serializerOptions);
            }
        }
        
        readonly ClientCore core;
        
        public ChatServiceClient(global::MagicOnion.Client.MagicOnionClientOptions options, global::MessagePack.MessagePackSerializerOptions serializerOptions) : base(options)
        {
            this.core = new ClientCore(serializerOptions);
        }
        
        private ChatServiceClient(global::MagicOnion.Client.MagicOnionClientOptions options, ClientCore core) : base(options)
        {
            this.core = core;
        }
        
        protected override global::MagicOnion.Client.MagicOnionClientBase<IChatService> Clone(global::MagicOnion.Client.MagicOnionClientOptions options)
            => new ChatServiceClient(options, core);
        
        public global::MagicOnion.UnaryResult<global::MessagePack.Nil> GenerateException(global::System.String message)
            => this.core.GenerateException.InvokeUnary(this, "IChatService/GenerateException", message);
        public global::MagicOnion.UnaryResult<global::MessagePack.Nil> SendReportAsync(global::System.String message)
            => this.core.SendReportAsync.InvokeUnary(this, "IChatService/SendReportAsync", message);
    }
}


#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace ChatApp.Shared.Hubs {
    using Grpc.Core;
    using MagicOnion;
    using MagicOnion.Client;
    using MessagePack;
    using System;
    using System.Threading.Tasks;

    [Ignore]
    public class ChatHubClient : StreamingHubClientBase<global::ChatApp.Shared.Hubs.IChatHub, global::ChatApp.Shared.Hubs.IChatHubReceiver>, global::ChatApp.Shared.Hubs.IChatHub
    {
        static readonly Method<byte[], byte[]> method = new Method<byte[], byte[]>(MethodType.DuplexStreaming, "IChatHub", "Connect", MagicOnionMarshallers.ThroughMarshaller, MagicOnionMarshallers.ThroughMarshaller);

        protected override Method<byte[], byte[]> DuplexStreamingAsyncMethod { get { return method; } }

        readonly global::ChatApp.Shared.Hubs.IChatHub __fireAndForgetClient;

        public ChatHubClient(CallInvoker callInvoker, string host, CallOptions option, MessagePackSerializerOptions serializerOptions, IMagicOnionClientLogger logger)
            : base(callInvoker, host, option, serializerOptions, logger)
        {
            this.__fireAndForgetClient = new FireAndForgetClient(this);
        }
        
        public global::ChatApp.Shared.Hubs.IChatHub FireAndForget()
        {
            return __fireAndForgetClient;
        }

        protected override void OnBroadcastEvent(int methodId, ArraySegment<byte> data)
        {
            switch (methodId)
            {
                case -1297457280: // OnJoin
                {
                    var result = MessagePackSerializer.Deserialize<global::System.String>(data, serializerOptions);
                    receiver.OnJoin(result); break;
                }
                case 532410095: // OnLeave
                {
                    var result = MessagePackSerializer.Deserialize<global::System.String>(data, serializerOptions);
                    receiver.OnLeave(result); break;
                }
                case -552695459: // OnSendMessage
                {
                    var result = MessagePackSerializer.Deserialize<global::ChatApp.Shared.MessagePackObjects.MessageResponse>(data, serializerOptions);
                    receiver.OnSendMessage(result); break;
                }
                default:
                    break;
            }
        }

        protected override void OnResponseEvent(int methodId, object taskCompletionSource, ArraySegment<byte> data)
        {
            switch (methodId)
            {
                case -733403293: // JoinAsync
                {
                    var result = MessagePackSerializer.Deserialize<global::MessagePack.Nil>(data, serializerOptions);
                    ((TaskCompletionSource<global::MessagePack.Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case 1368362116: // LeaveAsync
                {
                    var result = MessagePackSerializer.Deserialize<global::MessagePack.Nil>(data, serializerOptions);
                    ((TaskCompletionSource<global::MessagePack.Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case -601690414: // SendMessageAsync
                {
                    var result = MessagePackSerializer.Deserialize<global::MessagePack.Nil>(data, serializerOptions);
                    ((TaskCompletionSource<global::MessagePack.Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case 517938971: // GenerateException
                {
                    var result = MessagePackSerializer.Deserialize<global::MessagePack.Nil>(data, serializerOptions);
                    ((TaskCompletionSource<global::MessagePack.Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case -852153394: // SampleMethod
                {
                    var result = MessagePackSerializer.Deserialize<global::MessagePack.Nil>(data, serializerOptions);
                    ((TaskCompletionSource<global::MessagePack.Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                default:
                    break;
            }
        }
   
        public global::System.Threading.Tasks.Task JoinAsync(global::ChatApp.Shared.MessagePackObjects.JoinRequest request)
        {
            return WriteMessageWithResponseAsync<global::ChatApp.Shared.MessagePackObjects.JoinRequest, global::MessagePack.Nil>(-733403293, request);
        }

        public global::System.Threading.Tasks.Task LeaveAsync()
        {
            return WriteMessageWithResponseAsync<global::MessagePack.Nil, global::MessagePack.Nil>(1368362116, global::MessagePack.Nil.Default);
        }

        public global::System.Threading.Tasks.Task SendMessageAsync(global::System.String message)
        {
            return WriteMessageWithResponseAsync<global::System.String, global::MessagePack.Nil>(-601690414, message);
        }

        public global::System.Threading.Tasks.Task GenerateException(global::System.String message)
        {
            return WriteMessageWithResponseAsync<global::System.String, global::MessagePack.Nil>(517938971, message);
        }

        public global::System.Threading.Tasks.Task SampleMethod(global::System.Collections.Generic.List<global::System.Int32> sampleList, global::System.Collections.Generic.Dictionary<global::System.Int32, global::System.String> sampleDictionary)
        {
            return WriteMessageWithResponseAsync<global::MagicOnion.DynamicArgumentTuple<global::System.Collections.Generic.List<global::System.Int32>, global::System.Collections.Generic.Dictionary<global::System.Int32, global::System.String>>, global::MessagePack.Nil>(-852153394, new global::MagicOnion.DynamicArgumentTuple<global::System.Collections.Generic.List<global::System.Int32>, global::System.Collections.Generic.Dictionary<global::System.Int32, global::System.String>>(sampleList, sampleDictionary));
        }


        [Ignore]
        class FireAndForgetClient : global::ChatApp.Shared.Hubs.IChatHub
        {
            readonly ChatHubClient __parent;

            public FireAndForgetClient(ChatHubClient parentClient)
            {
                this.__parent = parentClient;
            }

            public global::ChatApp.Shared.Hubs.IChatHub FireAndForget()
            {
                throw new NotSupportedException();
            }

            public Task DisposeAsync()
            {
                throw new NotSupportedException();
            }

            public Task WaitForDisconnect()
            {
                throw new NotSupportedException();
            }

            public global::System.Threading.Tasks.Task JoinAsync(global::ChatApp.Shared.MessagePackObjects.JoinRequest request)
            {
                return __parent.WriteMessageWithResponseAsync<global::ChatApp.Shared.MessagePackObjects.JoinRequest, global::MessagePack.Nil>(-733403293, request);
            }

            public global::System.Threading.Tasks.Task LeaveAsync()
            {
                return __parent.WriteMessageWithResponseAsync<global::MessagePack.Nil, global::MessagePack.Nil>(1368362116, global::MessagePack.Nil.Default);
            }

            public global::System.Threading.Tasks.Task SendMessageAsync(global::System.String message)
            {
                return __parent.WriteMessageWithResponseAsync<global::System.String, global::MessagePack.Nil>(-601690414, message);
            }

            public global::System.Threading.Tasks.Task GenerateException(global::System.String message)
            {
                return __parent.WriteMessageWithResponseAsync<global::System.String, global::MessagePack.Nil>(517938971, message);
            }

            public global::System.Threading.Tasks.Task SampleMethod(global::System.Collections.Generic.List<global::System.Int32> sampleList, global::System.Collections.Generic.Dictionary<global::System.Int32, global::System.String> sampleDictionary)
            {
                return __parent.WriteMessageWithResponseAsync<global::MagicOnion.DynamicArgumentTuple<global::System.Collections.Generic.List<global::System.Int32>, global::System.Collections.Generic.Dictionary<global::System.Int32, global::System.String>>, global::MessagePack.Nil>(-852153394, new global::MagicOnion.DynamicArgumentTuple<global::System.Collections.Generic.List<global::System.Int32>, global::System.Collections.Generic.Dictionary<global::System.Int32, global::System.String>>(sampleList, sampleDictionary));
            }

        }
    }
}

#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
