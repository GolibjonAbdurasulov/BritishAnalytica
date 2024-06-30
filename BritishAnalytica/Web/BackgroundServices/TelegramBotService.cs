using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Web.BackgroundServices;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

public class TelegramBotService : BackgroundService
{
    private readonly ILogger<TelegramBotService> _logger;
    private readonly TelegramBotClient _botClient;
    private readonly TelegramBotSetting _botSettings;

    public TelegramBotService(ILogger<TelegramBotService> logger, IOptions<TelegramBotSetting> botSettings)
    {
        _logger = logger;
        _botSettings = botSettings.Value;
        _botClient = new TelegramBotClient(_botSettings.Token);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Telegram Bot Service is starting.");

        stoppingToken.Register(() =>
            _logger.LogInformation("Telegram Bot Service is stopping."));

        while (!stoppingToken.IsCancellationRequested)
        {
            // Handle incoming messages or other bot activities
            // Example: await _botClient.SendTextMessageAsync(chatId, "Hello!");

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken); // Example delay
        }

        _logger.LogInformation("Telegram Bot Service is stopped.");
    }
    
    public async Task SendMessageToAdminGroupAsync(string message)
    {
        try
        {
            var chatId = long.Parse(_botSettings.AdminGroupChatId);
            await _botClient.SendTextMessageAsync(chatId, message, ParseMode.Markdown);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Xabar yuborishda xatolik: {ex.Message}");
        }
    }
}